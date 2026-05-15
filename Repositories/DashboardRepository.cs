using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace Condominio.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IDbConnection _db;
        public DashboardRepository(IDbConnection db) { _db = db; }

        // ── GENERAL (sin cambios) ────────────────────────────
        public async Task<DashboardModel> GetDashboardAsync()
        {
            var dashboard = new DashboardModel();

            var residentes = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS TOTAL,
                       SUM(CASE WHEN ACTIVO=1 THEN 1 ELSE 0 END) AS ACTIVOS,
                       SUM(CASE WHEN ACTIVO=0 THEN 1 ELSE 0 END) AS INACTIVOS
                FROM RESIDENTE");
            dashboard.TotalResidentes = Convert.ToInt32(residentes?.TOTAL ?? 0);
            dashboard.ResidentesActivos = Convert.ToInt32(residentes?.ACTIVOS ?? 0);
            dashboard.ResidentesInactivos = Convert.ToInt32(residentes?.INACTIVOS ?? 0);

            var financiero = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT NVL(SUM(CASE WHEN TRUNC(FECHA_PAGO,'MM')=TRUNC(SYSDATE,'MM')
                                    THEN MONTO_PAGADO ELSE 0 END),0) AS COBRADOMES
                FROM PAGO WHERE ESTADO='CONFIRMADO'");
            dashboard.TotalCobradoMes = Convert.ToDecimal(financiero?.COBRADOMES ?? 0);

            var cuentas = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT NVL(SUM(MONTO_PENDIENTE),0) AS PENDIENTE,
                       NVL(SUM(MONTO_MORA),0) AS MORA,
                       SUM(CASE WHEN ESTADO='PENDIENTE' THEN 1 ELSE 0 END) AS FACTPENDIENTES,
                       SUM(CASE WHEN ESTADO='PENDIENTE' AND DIAS_ATRASO>0 THEN 1 ELSE 0 END) AS FACTVENCIDAS
                FROM CUENTA_POR_COBRAR");
            dashboard.TotalPendienteCobro = Convert.ToDecimal(cuentas?.PENDIENTE ?? 0);
            dashboard.TotalMora = Convert.ToDecimal(cuentas?.MORA ?? 0);
            dashboard.FacturasPendientes = Convert.ToInt32(cuentas?.FACTPENDIENTES ?? 0);
            dashboard.FacturasVencidas = Convert.ToInt32(cuentas?.FACTVENCIDAS ?? 0);

            var incidencias = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT SUM(CASE WHEN ESTADO='ABIERTA'    THEN 1 ELSE 0 END) AS ABIERTAS,
                       SUM(CASE WHEN ESTADO='EN_PROCESO' THEN 1 ELSE 0 END) AS ENPROCESO,
                       SUM(CASE WHEN ESTADO IN ('RESUELTA','CERRADA')
                                 AND TRUNC(FECHA_RESOLUCION,'MM')=TRUNC(SYSDATE,'MM')
                                THEN 1 ELSE 0 END) AS CERRADASMES
                FROM INCIDENCIA");
            dashboard.IncidenciasAbiertas = Convert.ToInt32(incidencias?.ABIERTAS ?? 0);
            dashboard.IncidenciasEnProceso = Convert.ToInt32(incidencias?.ENPROCESO ?? 0);
            dashboard.IncidenciasCerradasMes = Convert.ToInt32(incidencias?.CERRADASMES ?? 0);

            var acceso = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS ACCESOSHOY,
                       SUM(CASE WHEN TIPO_PERSONA='VISITANTE' THEN 1 ELSE 0 END) AS VISITASHOY
                FROM REGISTRO_ACCESO WHERE TRUNC(FECHA_HORA)=TRUNC(SYSDATE)");
            dashboard.AccesosHoy = Convert.ToInt32(acceso?.ACCESOSHOY ?? 0);
            dashboard.VisitasHoy = Convert.ToInt32(acceso?.VISITASHOY ?? 0);

            var espacios = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT SUM(CASE WHEN ESTADO='DISPONIBLE' THEN 1 ELSE 0 END) AS DISPONIBLES
                FROM ESPACIO_COMUN WHERE ACTIVO=1");
            dashboard.EspaciosDisponibles = Convert.ToInt32(espacios?.DISPONIBLES ?? 0);

            var reservas = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS RESERVASHOY FROM RESERVA_ESPACIO
                WHERE TRUNC(FECHA_RESERVA)=TRUNC(SYSDATE) AND ESTADO IN ('APROBADA','PENDIENTE')");
            dashboard.ReservasHoy = Convert.ToInt32(reservas?.RESERVASHOY ?? 0);

            var personal = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS TOTAL,
                       SUM(CASE WHEN ESTADO='ACTIVO' THEN 1 ELSE 0 END) AS ACTIVOS
                FROM EMPLEADO");
            dashboard.TotalEmpleados = Convert.ToInt32(personal?.TOTAL ?? 0);
            dashboard.EmpleadosActivos = Convert.ToInt32(personal?.ACTIVOS ?? 0);

            var multas = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS PENDIENTES, NVL(SUM(MONTO),0) AS MONTOTOTAL
                FROM MULTA WHERE ESTADO='PENDIENTE'");
            dashboard.MultasPendientes = Convert.ToInt32(multas?.PENDIENTES ?? 0);
            dashboard.MontoMultasPendientes = Convert.ToDecimal(multas?.MONTOTOTAL ?? 0);

            var pagosMes = await _db.QueryAsync<dynamic>(@"
                SELECT TO_CHAR(FECHA_PAGO,'MON-YY') AS MES, SUM(MONTO_PAGADO) AS TOTAL
                FROM PAGO WHERE ESTADO='CONFIRMADO' AND FECHA_PAGO>=ADD_MONTHS(SYSDATE,-6)
                GROUP BY TO_CHAR(FECHA_PAGO,'MON-YY'), TRUNC(FECHA_PAGO,'MM')
                ORDER BY TRUNC(FECHA_PAGO,'MM')");
            dashboard.PagosPorMes = pagosMes.Select(r => new PagoMensualItem
            { Mes = (string)r.MES, Total = Convert.ToDecimal(r.TOTAL) }).ToList();

            var incPorCat = await _db.QueryAsync<dynamic>(@"
                SELECT NVL(ci.NOMBRE,'Sin categoría') AS CATEGORIA, COUNT(*) AS TOTAL
                FROM INCIDENCIA i
                LEFT JOIN CATEGORIA_INCIDENCIA ci ON ci.ID_CATEGORIA=i.ID_CATEGORIA
                WHERE i.ESTADO NOT IN ('CERRADA','RESUELTA')
                GROUP BY ci.NOMBRE ORDER BY COUNT(*) DESC");
            dashboard.IncidenciasPorCategoria = incPorCat.Select(r => new IncidenciaPorCategoriaItem
            { Categoria = (string)r.CATEGORIA, Total = Convert.ToInt32(r.TOTAL) }).ToList();

            var morosos = await _db.QueryAsync<dynamic>(@"
                SELECT * FROM (
                    SELECT p.NOMBRES||' '||p.APELLIDOS AS RESIDENTE,
                           cpc.MONTO_PENDIENTE, cpc.DIAS_ATRASO
                    FROM CUENTA_POR_COBRAR cpc
                    JOIN RESIDENTE r ON r.ID_RESIDENTE=cpc.ID_RESIDENTE
                    JOIN PERSONA p   ON p.ID_PERSONA=r.ID_PERSONA
                    WHERE cpc.ESTADO IN ('PENDIENTE','PARCIAL') AND cpc.MONTO_PENDIENTE>0
                    ORDER BY cpc.MONTO_PENDIENTE DESC) WHERE ROWNUM<=5");
            dashboard.TopMorosos = morosos.Select(r => new MorososItem
            {
                Residente = (string)r.RESIDENTE,
                MontoPendiente = Convert.ToDecimal(r.MONTO_PENDIENTE),
                DiasAtraso = Convert.ToInt32(r.DIAS_ATRASO)
            }).ToList();

            return dashboard;
        }

        // ── FINANCIERO ───────────────────────────────────────
        public async Task<DashboardFinancieroModel> GetDashboardFinancieroAsync()
        {
            var d = new DashboardFinancieroModel();

            var kpi = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT NVL(SUM(CASE WHEN TRUNC(FECHA_PAGO,'MM')=TRUNC(SYSDATE,'MM')
                                    THEN MONTO_PAGADO ELSE 0 END),0) AS COBMES,
                       NVL(SUM(CASE WHEN TRUNC(FECHA_PAGO,'YYYY')=TRUNC(SYSDATE,'YYYY')
                                    THEN MONTO_PAGADO ELSE 0 END),0) AS COBANIOO
                FROM PAGO WHERE ESTADO='CONFIRMADO'");
            d.TotalCobradoMes = Convert.ToDecimal(kpi?.COBMES ?? 0);
            d.TotalCobradoAnio = Convert.ToDecimal(kpi?.COBANIOO ?? 0);

            var cart = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT NVL(SUM(MONTO_PENDIENTE),0) AS PEND,
                       NVL(SUM(MONTO_MORA),0) AS MORA,
                       SUM(CASE WHEN ESTADO='PENDIENTE' THEN 1 ELSE 0 END) AS FP,
                       SUM(CASE WHEN ESTADO='PENDIENTE' AND DIAS_ATRASO>0 THEN 1 ELSE 0 END) AS FV,
                       NVL(AVG(CASE WHEN DIAS_ATRASO>0 THEN DIAS_ATRASO END),0) AS PROMDIA
                FROM CUENTA_POR_COBRAR");
            d.TotalPendiente = Convert.ToDecimal(cart?.PEND ?? 0);
            d.TotalMora = Convert.ToDecimal(cart?.MORA ?? 0);
            d.FacturasPendientes = Convert.ToInt32(cart?.FP ?? 0);
            d.FacturasVencidas = Convert.ToInt32(cart?.FV ?? 0);
            d.PromedioMoraDias = Convert.ToDecimal(cart?.PROMDIA ?? 0);

            var saf = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT NVL(SUM(MONTO_DISPONIBLE),0) AS T FROM SALDO_A_FAVOR WHERE ESTADO='DISPONIBLE'");
            d.TotalSaldosAFavor = Convert.ToDecimal(saf?.T ?? 0);

            var acu = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS T FROM ACUERDO_PAGO WHERE ESTADO='ACTIVO'");
            d.AcuerdosPagoActivos = Convert.ToInt32(acu?.T ?? 0);

            var ingresos = await _db.QueryAsync<dynamic>(@"
                SELECT TO_CHAR(TRUNC(FECHA_PAGO,'MM'),'MON-YY') AS MES,
                       TRUNC(FECHA_PAGO,'MM') AS FORD,
                       NVL(SUM(MONTO_PAGADO),0) AS TOTAL, COUNT(*) AS NPAGOS
                FROM PAGO WHERE ESTADO='CONFIRMADO'
                  AND FECHA_PAGO>=ADD_MONTHS(TRUNC(SYSDATE,'MM'),-11)
                GROUP BY TO_CHAR(TRUNC(FECHA_PAGO,'MM'),'MON-YY'),TRUNC(FECHA_PAGO,'MM')
                ORDER BY TRUNC(FECHA_PAGO,'MM')");
            d.IngresosPorMes = ingresos.Select(r => new IngresoMensualItem
            { Mes = (string)r.MES, TotalIngresos = Convert.ToDecimal(r.TOTAL), NumPagos = Convert.ToInt32(r.NPAGOS) }).ToList();

            var distCart = await _db.QueryAsync<dynamic>(@"
                SELECT ESTADO, COUNT(*) AS CANT, NVL(SUM(MONTO_PENDIENTE),0) AS MONTO
                FROM CUENTA_POR_COBRAR GROUP BY ESTADO ORDER BY MONTO DESC");
            d.DistribucionCartera = distCart.Select(r => new CarteraItem
            { Estado = (string)r.ESTADO, Cantidad = Convert.ToInt32(r.CANT), Monto = Convert.ToDecimal(r.MONTO) }).ToList();

            var metodos = await _db.QueryAsync<dynamic>(@"
                SELECT NVL(mp.NOMBRE,'Sin especificar') AS METODO,
                       COUNT(p.ID_PAGO) AS CANT, NVL(SUM(p.MONTO_PAGADO),0) AS TOTAL
                FROM PAGO p LEFT JOIN METODOPAGO mp ON mp.ID=p.ID_METODO_PAGO
                WHERE p.ESTADO='CONFIRMADO' AND p.FECHA_PAGO>=ADD_MONTHS(SYSDATE,-3)
                GROUP BY mp.NOMBRE ORDER BY TOTAL DESC");
            d.PagosPorMetodo = metodos.Select(r => new MetodoPagoItem
            { Metodo = (string)r.METODO, Cantidad = Convert.ToInt32(r.CANT), Total = Convert.ToDecimal(r.TOTAL) }).ToList();

            var morosos = await _db.QueryAsync<dynamic>(@"
                SELECT * FROM (
                    SELECT p.NOMBRES||' '||p.APELLIDOS AS RESIDENTE,
                           cpc.MONTO_PENDIENTE, cpc.DIAS_ATRASO
                    FROM CUENTA_POR_COBRAR cpc
                    JOIN RESIDENTE r ON r.ID_RESIDENTE=cpc.ID_RESIDENTE
                    JOIN PERSONA p   ON p.ID_PERSONA=r.ID_PERSONA
                    WHERE cpc.ESTADO IN ('PENDIENTE','PARCIAL') AND cpc.MONTO_PENDIENTE>0
                    ORDER BY cpc.MONTO_PENDIENTE DESC) WHERE ROWNUM<=10");
            d.TopMorosos = morosos.Select(r => new MorososItem
            { Residente = (string)r.RESIDENTE, MontoPendiente = Convert.ToDecimal(r.MONTO_PENDIENTE), DiasAtraso = Convert.ToInt32(r.DIAS_ATRASO) }).ToList();

            var svcs = await _db.QueryAsync<dynamic>(@"
                SELECT NVL(ts.NOMBRE,'Otros') AS SVC, NVL(SUM(df.TOTAL_LINEA),0) AS TOTAL
                FROM DETALLE_FACTURA df
                LEFT JOIN TIPO_SERVICIO ts ON ts.ID_TIPO_SERVICIO=df.ID_TIPO_SERVICIO
                JOIN FACTURA f ON f.ID_FACTURA=df.ID_FACTURA
                WHERE f.ESTADO IN ('PAGADA','PARCIALMENTE_PAGADA')
                  AND TRUNC(f.FECHA_EMISION,'MM')=TRUNC(SYSDATE,'MM')
                GROUP BY ts.NOMBRE ORDER BY TOTAL DESC");
            d.IngresosPorServicio = svcs.Select(r => new ServicioIngresosItem
            { Servicio = (string)r.SVC, Total = Convert.ToDecimal(r.TOTAL) }).ToList();

            return d;
        }

        // ── RESIDENTES ───────────────────────────────────────
        public async Task<DashboardResidentesModel> GetDashboardResidentesAsync()
        {
            var d = new DashboardResidentesModel();

            var props = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS T,
                       SUM(CASE WHEN ESTADO IN ('ALQUILADA','VENDIDA') THEN 1 ELSE 0 END) AS OC,
                       SUM(CASE WHEN ESTADO='DISPONIBLE' THEN 1 ELSE 0 END) AS DI,
                       SUM(CASE WHEN ESTADO='EN_MANTENIMIENTO' THEN 1 ELSE 0 END) AS MA
                FROM PROPIEDAD");
            d.TotalPropiedades = Convert.ToInt32(props?.T ?? 0);
            d.PropiedadesOcupadas = Convert.ToInt32(props?.OC ?? 0);
            d.PropiedadesDisponibles = Convert.ToInt32(props?.DI ?? 0);
            d.PropiedadesMantenimiento = Convert.ToInt32(props?.MA ?? 0);

            var res = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS T,
                       SUM(CASE WHEN TIPO_RESIDENTE='PROPIETARIO' THEN 1 ELSE 0 END) AS PR,
                       SUM(CASE WHEN TIPO_RESIDENTE='INQUILINO'   THEN 1 ELSE 0 END) AS IN2
                FROM RESIDENTE WHERE ACTIVO=1");
            d.TotalResidentes = Convert.ToInt32(res?.T ?? 0);
            d.Propietarios = Convert.ToInt32(res?.PR ?? 0);
            d.Inquilinos = Convert.ToInt32(res?.IN2 ?? 0);

            var veh = await _db.QueryFirstOrDefaultAsync<dynamic>(@"SELECT COUNT(*) AS T FROM VEHICULO WHERE ACTIVO=1");
            d.TotalVehiculos = Convert.ToInt32(veh?.T ?? 0);

            var fam = await _db.QueryFirstOrDefaultAsync<dynamic>(@"SELECT COUNT(*) AS T FROM FAMILIAR_RESIDENTE WHERE ACTIVO=1");
            d.TotalFamiliares = Convert.ToInt32(fam?.T ?? 0);

            var tiposQ = await _db.QueryAsync<dynamic>(@"
                SELECT tp.NOMBRE AS TIPO, COUNT(p.ID_PROPIEDAD) AS TOTAL,
                       SUM(CASE WHEN p.ESTADO IN ('ALQUILADA','VENDIDA') THEN 1 ELSE 0 END) AS OCUPADAS
                FROM TIPO_PROPIEDAD tp
                LEFT JOIN PROPIEDAD p ON p.ID_TIPO_PROPIEDAD=tp.ID_TIPO_PROPIEDAD
                GROUP BY tp.NOMBRE ORDER BY TOTAL DESC");
            d.PropiedadesPorTipo = tiposQ.Select(r => new TipoPropiedadItem
            { Tipo = (string)r.TIPO, Total = Convert.ToInt32(r.TOTAL), Ocupadas = Convert.ToInt32(r.OCUPADAS) }).ToList();

            var hist = await _db.QueryAsync<dynamic>(@"
                SELECT TO_CHAR(TRUNC(FECHA_INGRESO,'MM'),'MON-YY') AS MES,
                       TRUNC(FECHA_INGRESO,'MM') AS FORD, COUNT(*) AS INGRESOS
                FROM RESIDENTE WHERE FECHA_INGRESO>=ADD_MONTHS(SYSDATE,-6)
                GROUP BY TO_CHAR(TRUNC(FECHA_INGRESO,'MM'),'MON-YY'),TRUNC(FECHA_INGRESO,'MM')
                ORDER BY TRUNC(FECHA_INGRESO,'MM')");
            d.OcupacionHistorica = hist.Select(r => new OcupacionMensualItem
            { Mes = (string)r.MES, Ingresos = Convert.ToInt32(r.INGRESOS) }).ToList();

            var det = await _db.QueryAsync<dynamic>(@"
                SELECT * FROM (
                    SELECT p.NOMBRES||' '||p.APELLIDOS AS NOM, pr.CODIGO AS PROP,
                           r.TIPO_RESIDENTE, r.FECHA_INGRESO,
                           (SELECT COUNT(*) FROM FAMILIAR_RESIDENTE f WHERE f.ID_RESIDENTE=r.ID_RESIDENTE AND f.ACTIVO=1) AS NF,
                           (SELECT COUNT(*) FROM VEHICULO v         WHERE v.ID_RESIDENTE=r.ID_RESIDENTE  AND v.ACTIVO=1) AS NV
                    FROM RESIDENTE r
                    JOIN PERSONA p    ON p.ID_PERSONA=r.ID_PERSONA
                    JOIN PROPIEDAD pr ON pr.ID_PROPIEDAD=r.ID_PROPIEDAD
                    WHERE r.ACTIVO=1 ORDER BY r.FECHA_INGRESO DESC
                ) WHERE ROWNUM<=25");
            d.ResidentesDetalle = det.Select(r => new ResidenteDetalleItem
            {
                Nombre = r.NOM != null ? (string)r.NOM : "",
                Propiedad = r.PROP != null ? (string)r.PROP : "",
                TipoResidente = (string)r.TIPO_RESIDENTE,
                FechaIngreso = Convert.ToDateTime(r.FECHA_INGRESO),
                NumFamiliares = Convert.ToInt32(r.NF),
                NumVehiculos = Convert.ToInt32(r.NV)
            }).ToList();

            return d;
        }

        // ── ACCESO ───────────────────────────────────────────
        public async Task<DashboardAccesoModel> GetDashboardAccesoAsync()
        {
            var d = new DashboardAccesoModel();

            var hoy = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS AH,
                       SUM(CASE WHEN TIPO_PERSONA='VISITANTE' THEN 1 ELSE 0 END) AS VH,
                       SUM(CASE WHEN TIPO_MOVIMIENTO='ENTRADA' THEN 1 ELSE 0 END) AS EH,
                       SUM(CASE WHEN TIPO_MOVIMIENTO='SALIDA'  THEN 1 ELSE 0 END) AS SH
                FROM REGISTRO_ACCESO WHERE TRUNC(FECHA_HORA)=TRUNC(SYSDATE)");
            d.AccesosHoy = Convert.ToInt32(hoy?.AH ?? 0);
            d.VisitasHoy = Convert.ToInt32(hoy?.VH ?? 0);
            d.EntradasHoy = Convert.ToInt32(hoy?.EH ?? 0);
            d.SalidasHoy = Convert.ToInt32(hoy?.SH ?? 0);

            var ln = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT SUM(CASE WHEN TIPO='PERSONA'  THEN 1 ELSE 0 END) AS PE,
                       SUM(CASE WHEN TIPO='VEHICULO' THEN 1 ELSE 0 END) AS VE
                FROM LISTA_NEGRA WHERE ACTIVO=1");
            d.PersonasEnLista = Convert.ToInt32(ln?.PE ?? 0);
            d.VehiculosEnLista = Convert.ToInt32(ln?.VE ?? 0);

            var va = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS T FROM VISITA_AUTORIZADA
                WHERE ESTADO='ACTIVA' AND FECHA_DESDE<=SYSDATE
                  AND (FECHA_HASTA IS NULL OR FECHA_HASTA>=SYSDATE)");
            d.VisitasActivasHoy = Convert.ToInt32(va?.T ?? 0);

            var porDia = await _db.QueryAsync<dynamic>(@"
                SELECT TO_CHAR(TRUNC(FECHA_HORA),'DD/MM') AS FECHA,
                       TRUNC(FECHA_HORA) AS FORD,
                       SUM(CASE WHEN TIPO_MOVIMIENTO='ENTRADA' THEN 1 ELSE 0 END) AS ENT,
                       SUM(CASE WHEN TIPO_MOVIMIENTO='SALIDA'  THEN 1 ELSE 0 END) AS SAL,
                       COUNT(*) AS TOT
                FROM REGISTRO_ACCESO WHERE FECHA_HORA>=SYSDATE-14
                GROUP BY TO_CHAR(TRUNC(FECHA_HORA),'DD/MM'),TRUNC(FECHA_HORA)
                ORDER BY TRUNC(FECHA_HORA)");
            d.AccesosPorDia = porDia.Select(r => new AccesoDiarioItem
            { Fecha = (string)r.FECHA, Entradas = Convert.ToInt32(r.ENT), Salidas = Convert.ToInt32(r.SAL), Total = Convert.ToInt32(r.TOT) }).ToList();

            var porTipo = await _db.QueryAsync<dynamic>(@"
                SELECT TIPO_PERSONA, COUNT(*) AS TOT FROM REGISTRO_ACCESO
                WHERE FECHA_HORA>=SYSDATE-30 GROUP BY TIPO_PERSONA ORDER BY TOT DESC");
            d.AccesosPorTipo = porTipo.Select(r => new TipoPersonaAccesoItem
            { TipoPersona = (string)r.TIPO_PERSONA, Total = Convert.ToInt32(r.TOT) }).ToList();

            var porHora = await _db.QueryAsync<dynamic>(@"
                SELECT EXTRACT(HOUR FROM FECHA_HORA) AS HORA, COUNT(*) AS TOT
                FROM REGISTRO_ACCESO WHERE FECHA_HORA>=SYSDATE-7
                GROUP BY EXTRACT(HOUR FROM FECHA_HORA) ORDER BY HORA");
            d.AccesosPorHora = porHora.Select(r => new HoraAccesoItem
            { Hora = Convert.ToInt32(r.HORA), Total = Convert.ToInt32(r.TOT) }).ToList();

            var lnDet = await _db.QueryAsync<dynamic>(@"
                SELECT * FROM (
                    SELECT TIPO,
                           NVL(NOMBRES,(SELECT p.NOMBRES||' '||p.APELLIDOS
                                        FROM PERSONA p WHERE p.ID_PERSONA=ln.ID_PERSONA)) AS NOM,
                           MOTIVO, FECHA_FIN
                    FROM LISTA_NEGRA ln WHERE ACTIVO=1 ORDER BY FECHA_REGISTRO DESC
                ) WHERE ROWNUM<=10");
            d.ListaNegra = lnDet.Select(r => new ListaNegraItem
            {
                Tipo = (string)r.TIPO,
                Nombre = r.NOM != null ? (string)r.NOM : "N/A",
                Motivo = (string)r.MOTIVO,
                FechaFin = r.FECHA_FIN != null ? (DateTime?)Convert.ToDateTime(r.FECHA_FIN) : null
            }).ToList();

            return d;
        }

        // ── INCIDENCIAS ──────────────────────────────────────────────
        public async Task<DashboardIncidenciasModel> GetDashboardIncidenciasAsync()
        {
            var d = new DashboardIncidenciasModel();

            var kpi = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
        SELECT SUM(CASE WHEN ESTADO='ABIERTA'    THEN 1 ELSE 0 END) AS AB,
               SUM(CASE WHEN ESTADO='EN_PROCESO' THEN 1 ELSE 0 END) AS EP,
               SUM(CASE WHEN ESTADO IN ('RESUELTA','CERRADA') THEN 1 ELSE 0 END) AS RE,
               SUM(CASE WHEN PRIORIDAD='ALTA'  THEN 1 ELSE 0 END) AS AL,
               SUM(CASE WHEN PRIORIDAD='MEDIA' THEN 1 ELSE 0 END) AS ME,
               SUM(CASE WHEN PRIORIDAD='BAJA'  THEN 1 ELSE 0 END) AS BA,
               NVL(SUM(COSTO_ESTIMADO),0) AS CEST,
               NVL(SUM(COSTO_REAL),0)     AS CREAL,
               NVL(AVG(CASE WHEN FECHA_RESOLUCION IS NOT NULL
                            THEN (TRUNC(FECHA_RESOLUCION) - TRUNC(FECHA_APERTURA)) * 24
                       END), 0) AS HPROM
        FROM INCIDENCIA");

            d.TotalAbiertas = Convert.ToInt32(kpi?.AB ?? 0);
            d.TotalEnProceso = Convert.ToInt32(kpi?.EP ?? 0);
            d.TotalResueltas = Convert.ToInt32(kpi?.RE ?? 0);
            d.TotalAlta = Convert.ToInt32(kpi?.AL ?? 0);
            d.TotalMedia = Convert.ToInt32(kpi?.ME ?? 0);
            d.TotalBaja = Convert.ToInt32(kpi?.BA ?? 0);
            d.CostoEstimadoTotal = Convert.ToDecimal(kpi?.CEST ?? 0);
            d.CostoRealTotal = Convert.ToDecimal(kpi?.CREAL ?? 0);
            d.PromedioHorasResolucion = Convert.ToDouble(kpi?.HPROM ?? 0);

            var cat = await _db.QueryAsync<dynamic>(@"
        SELECT NVL(ci.NOMBRE,'Sin categoría') AS CAT,
               SUM(CASE WHEN i.ESTADO='ABIERTA'    THEN 1 ELSE 0 END) AS AB,
               SUM(CASE WHEN i.ESTADO='EN_PROCESO' THEN 1 ELSE 0 END) AS EP,
               SUM(CASE WHEN i.ESTADO IN ('RESUELTA','CERRADA') THEN 1 ELSE 0 END) AS RE,
               SUM(CASE WHEN i.PRIORIDAD='ALTA'  THEN 1 ELSE 0 END) AS AL,
               SUM(CASE WHEN i.PRIORIDAD='MEDIA' THEN 1 ELSE 0 END) AS ME,
               SUM(CASE WHEN i.PRIORIDAD='BAJA'  THEN 1 ELSE 0 END) AS BA
        FROM INCIDENCIA i
        LEFT JOIN CATEGORIA_INCIDENCIA ci ON ci.ID_CATEGORIA = i.ID_CATEGORIA
        GROUP BY ci.NOMBRE
        ORDER BY COUNT(*) DESC");

            d.PorCategoria = cat.Select(r => new IncidenciaCategoriaDetalle
            {
                Categoria = (string)r.CAT,
                Abiertas = Convert.ToInt32(r.AB),
                EnProceso = Convert.ToInt32(r.EP),
                Resueltas = Convert.ToInt32(r.RE),
                Alta = Convert.ToInt32(r.AL),
                Media = Convert.ToInt32(r.ME),
                Baja = Convert.ToInt32(r.BA)
            }).ToList();

            var tend = await _db.QueryAsync<dynamic>(@"
        SELECT TO_CHAR(TRUNC(FECHA_APERTURA,'MM'),'MON-YY') AS MES,
               TRUNC(FECHA_APERTURA,'MM') AS FORD,
               COUNT(*) AS AB,
               SUM(CASE WHEN ESTADO IN ('RESUELTA','CERRADA') THEN 1 ELSE 0 END) AS RE
        FROM INCIDENCIA
        WHERE FECHA_APERTURA >= ADD_MONTHS(TRUNC(SYSDATE,'MM'),-6)
        GROUP BY TO_CHAR(TRUNC(FECHA_APERTURA,'MM'),'MON-YY'), TRUNC(FECHA_APERTURA,'MM')
        ORDER BY TRUNC(FECHA_APERTURA,'MM')");

            d.TendenciaMensual = tend.Select(r => new IncidenciaTendenciaItem
            {
                Mes = (string)r.MES,
                Abiertas = Convert.ToInt32(r.AB),
                Resueltas = Convert.ToInt32(r.RE)
            }).ToList();

            var rec = await _db.QueryAsync<dynamic>(@"
        SELECT * FROM (
            SELECT i.TITULO,
                   NVL(ci.NOMBRE,'Sin categoría') AS CAT,
                   i.PRIORIDAD,
                   i.ESTADO,
                   TRUNC(i.FECHA_APERTURA) AS FECHA_APERTURA,
                   NVL(p.CODIGO,'Área común') AS PROP
            FROM INCIDENCIA i
            LEFT JOIN CATEGORIA_INCIDENCIA ci ON ci.ID_CATEGORIA = i.ID_CATEGORIA
            LEFT JOIN PROPIEDAD p             ON p.ID_PROPIEDAD  = i.ID_PROPIEDAD
            WHERE i.ESTADO NOT IN ('CERRADA','RESUELTA')
            ORDER BY CASE i.PRIORIDAD
                         WHEN 'ALTA'  THEN 1
                         WHEN 'MEDIA' THEN 2
                         ELSE 3
                     END,
                     i.FECHA_APERTURA DESC
        ) WHERE ROWNUM <= 15");

            d.IncidenciasRecientes = rec.Select(r => new IncidenciaDetalleItem
            {
                Titulo = (string)r.TITULO,
                Categoria = (string)r.CAT,
                Prioridad = (string)r.PRIORIDAD,
                Estado = (string)r.ESTADO,
                FechaApertura = Convert.ToDateTime(r.FECHA_APERTURA),
                Propiedad = (string)r.PROP
            }).ToList();

            return d;
        }

        // ── ESPACIOS ─────────────────────────────────────────
        public async Task<DashboardEspaciosModel> GetDashboardEspaciosAsync()
        {
            var d = new DashboardEspaciosModel();

            var kpi = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS TOT,
                       SUM(CASE WHEN ESTADO='DISPONIBLE'      THEN 1 ELSE 0 END) AS DI,
                       SUM(CASE WHEN ESTADO='EN_MANTENIMIENTO' THEN 1 ELSE 0 END) AS MA
                FROM ESPACIO_COMUN WHERE ACTIVO=1");
            d.TotalEspacios = Convert.ToInt32(kpi?.TOT ?? 0);
            d.EspaciosDisponibles = Convert.ToInt32(kpi?.DI ?? 0);
            d.EspaciosMantenimiento = Convert.ToInt32(kpi?.MA ?? 0);

            var rkpi = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT SUM(CASE WHEN TRUNC(FECHA_RESERVA)=TRUNC(SYSDATE) THEN 1 ELSE 0 END) AS HOY,
                       SUM(CASE WHEN TRUNC(FECHA_RESERVA,'MM')=TRUNC(SYSDATE,'MM') THEN 1 ELSE 0 END) AS MES,
                       NVL(SUM(CASE WHEN TRUNC(FECHA_RESERVA,'MM')=TRUNC(SYSDATE,'MM')
                                    THEN MONTO_COBRO ELSE 0 END),0) AS INGMES,
                       NVL(SUM(CASE WHEN DEPOSITO_COBRADO>0 AND DEPOSITO_DEVUELTO=0
                                    THEN DEPOSITO_COBRADO ELSE 0 END),0) AS DEPEND
                FROM RESERVA_ESPACIO WHERE ESTADO IN ('APROBADA','COMPLETADA','PENDIENTE')");
            d.ReservasHoy = Convert.ToInt32(rkpi?.HOY ?? 0);
            d.ReservasMes = Convert.ToInt32(rkpi?.MES ?? 0);
            d.IngresosReservasMes = Convert.ToDecimal(rkpi?.INGMES ?? 0);
            d.DepositosPendientesDevolucion = Convert.ToDecimal(rkpi?.DEPEND ?? 0);

            var pEsp = await _db.QueryAsync<dynamic>(@"
                SELECT ec.NOMBRE AS ESP, COUNT(re.ID_RESERVA) AS TOT,
                       SUM(CASE WHEN re.ESTADO='APROBADA'  THEN 1 ELSE 0 END) AS AP,
                       SUM(CASE WHEN re.ESTADO='PENDIENTE' THEN 1 ELSE 0 END) AS PE,
                       NVL(SUM(CASE WHEN TRUNC(re.FECHA_RESERVA,'MM')=TRUNC(SYSDATE,'MM')
                                    THEN re.MONTO_COBRO ELSE 0 END),0) AS ING
                FROM ESPACIO_COMUN ec
                LEFT JOIN RESERVA_ESPACIO re ON re.ID_ESPACIO=ec.ID_ESPACIO
                WHERE ec.ACTIVO=1 GROUP BY ec.NOMBRE ORDER BY TOT DESC");
            d.ReservasPorEspacio = pEsp.Select(r => new EspacioReservaItem
            {
                Espacio = (string)r.ESP,
                TotalReservas = Convert.ToInt32(r.TOT),
                Aprobadas = Convert.ToInt32(r.AP),
                Pendientes = Convert.ToInt32(r.PE),
                Ingresos = Convert.ToDecimal(r.ING)
            }).ToList();

            var tend = await _db.QueryAsync<dynamic>(@"
                SELECT TO_CHAR(TRUNC(FECHA_RESERVA,'MM'),'MON-YY') AS MES,
                       TRUNC(FECHA_RESERVA,'MM') AS FORD,
                       COUNT(*) AS TOT, NVL(SUM(MONTO_COBRO),0) AS ING
                FROM RESERVA_ESPACIO WHERE FECHA_RESERVA>=ADD_MONTHS(SYSDATE,-6)
                GROUP BY TO_CHAR(TRUNC(FECHA_RESERVA,'MM'),'MON-YY'),TRUNC(FECHA_RESERVA,'MM')
                ORDER BY TRUNC(FECHA_RESERVA,'MM')");
            d.TendenciaMensual = tend.Select(r => new ReservaTendenciaItem
            { Mes = (string)r.MES, TotalReservas = Convert.ToInt32(r.TOT), Ingresos = Convert.ToDecimal(r.ING) }).ToList();

            var prox = await _db.QueryAsync<dynamic>(@"
                SELECT * FROM (
                    SELECT ec.NOMBRE AS ESP, p.NOMBRES||' '||p.APELLIDOS AS RES,
                           pr.CODIGO AS PROP, re.FECHA_RESERVA, re.HORA_INICIO, re.HORA_FIN, re.ESTADO
                    FROM RESERVA_ESPACIO re
                    JOIN ESPACIO_COMUN ec ON ec.ID_ESPACIO=re.ID_ESPACIO
                    JOIN RESIDENTE r ON r.ID_RESIDENTE=re.ID_RESIDENTE
                    JOIN PERSONA p   ON p.ID_PERSONA=r.ID_PERSONA
                    JOIN PROPIEDAD pr ON pr.ID_PROPIEDAD=re.ID_PROPIEDAD
                    WHERE re.FECHA_RESERVA>=TRUNC(SYSDATE) AND re.ESTADO IN ('APROBADA','PENDIENTE')
                    ORDER BY re.FECHA_RESERVA, re.HORA_INICIO
                ) WHERE ROWNUM<=10");
            d.ProximasReservas = prox.Select(r => new ReservaDetalleItem
            {
                Espacio = (string)r.ESP,
                Residente = (string)r.RES,
                Propiedad = (string)r.PROP,
                FechaReserva = Convert.ToDateTime(r.FECHA_RESERVA),
                HoraInicio = (string)r.HORA_INICIO,
                HoraFin = (string)r.HORA_FIN,
                Estado = (string)r.ESTADO
            }).ToList();

            return d;
        }

        // ── PERSONAL ─────────────────────────────────────────
        public async Task<DashboardPersonalModel> GetDashboardPersonalAsync()
        {
            var d = new DashboardPersonalModel();

            var kpi = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS TOT,
                       SUM(CASE WHEN ESTADO='ACTIVO'     THEN 1 ELSE 0 END) AS AC,
                       SUM(CASE WHEN ESTADO='SUSPENDIDO' THEN 1 ELSE 0 END) AS SU,
                       SUM(CASE WHEN ESTADO='BAJA'       THEN 1 ELSE 0 END) AS BA,
                       NVL(SUM(CASE WHEN ESTADO='ACTIVO' THEN SALARIO ELSE 0 END),0) AS NOM
                FROM EMPLEADO");
            d.TotalEmpleados = Convert.ToInt32(kpi?.TOT ?? 0);
            d.EmpleadosActivos = Convert.ToInt32(kpi?.AC ?? 0);
            d.EmpleadosSuspendidos = Convert.ToInt32(kpi?.SU ?? 0);
            d.EmpleadosBaja = Convert.ToInt32(kpi?.BA ?? 0);
            d.TotalNominaActual = Convert.ToDecimal(kpi?.NOM ?? 0);

            var asi = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT SUM(CASE WHEN ESTADO='PRESENTE' THEN 1 ELSE 0 END) AS PR,
                       SUM(CASE WHEN ESTADO='AUSENTE'  THEN 1 ELSE 0 END) AS AU,
                       SUM(CASE WHEN ESTADO='TARDE'    THEN 1 ELSE 0 END) AS TA
                FROM ASISTENCIA WHERE TRUNC(FECHA)=TRUNC(SYSDATE)");
            d.PresentesHoy = Convert.ToInt32(asi?.PR ?? 0);
            d.AusentesHoy = Convert.ToInt32(asi?.AU ?? 0);
            d.TardesHoy = Convert.ToInt32(asi?.TA ?? 0);

            var cargo = await _db.QueryAsync<dynamic>(@"
                SELECT c.NOMBRE AS CAR, COUNT(e.ID_EMPLEADO) AS TOT,
                       NVL(AVG(e.SALARIO),0) AS SPRM
                FROM CARGO c LEFT JOIN EMPLEADO e ON e.ID_CARGO=c.ID_CARGO AND e.ESTADO='ACTIVO'
                GROUP BY c.NOMBRE HAVING COUNT(e.ID_EMPLEADO)>0 ORDER BY TOT DESC");
            d.DistribucionPorCargo = cargo.Select(r => new EmpleadoCargoDist
            { Cargo = (string)r.CAR, Total = Convert.ToInt32(r.TOT), SalarioPromedio = Convert.ToDecimal(r.SPRM) }).ToList();

            var asisM = await _db.QueryAsync<dynamic>(@"
                SELECT p.NOMBRES||' '||p.APELLIDOS AS EMP, c.NOMBRE AS CAR,
                       SUM(CASE WHEN a.ESTADO='PRESENTE'   THEN 1 ELSE 0 END) AS PR,
                       SUM(CASE WHEN a.ESTADO='TARDE'      THEN 1 ELSE 0 END) AS TA,
                       SUM(CASE WHEN a.ESTADO='AUSENTE'    THEN 1 ELSE 0 END) AS AU,
                       SUM(CASE WHEN a.ESTADO='PERMISO'    THEN 1 ELSE 0 END) AS PE,
                       NVL(SUM(a.MINUTOS_EXTRA),0) AS ME
                FROM EMPLEADO e
                JOIN PERSONA p ON p.ID_PERSONA=e.ID_PERSONA
                JOIN CARGO c   ON c.ID_CARGO=e.ID_CARGO
                LEFT JOIN ASISTENCIA a ON a.ID_EMPLEADO=e.ID_EMPLEADO
                    AND TRUNC(a.FECHA,'MM')=TRUNC(SYSDATE,'MM')
                WHERE e.ESTADO='ACTIVO'
                GROUP BY p.NOMBRES,p.APELLIDOS,c.NOMBRE ORDER BY AU DESC,TA DESC");
            d.AsistenciaMes = asisM.Select(r => new AsistenciaResumenItem
            {
                Empleado = (string)r.EMP,
                Cargo = (string)r.CAR,
                Presentes = Convert.ToInt32(r.PR),
                Tardanzas = Convert.ToInt32(r.TA),
                Ausentes = Convert.ToInt32(r.AU),
                Permisos = Convert.ToInt32(r.PE),
                MinutosExtra = Convert.ToInt32(r.ME)
            }).ToList();

            var det = await _db.QueryAsync<dynamic>(@"
                SELECT p.NOMBRES||' '||p.APELLIDOS AS NOM, c.NOMBRE AS CAR,
                       e.ESTADO, e.SALARIO, e.FECHA_INGRESO, e.TIPO_JORNADA
                FROM EMPLEADO e
                JOIN PERSONA p ON p.ID_PERSONA=e.ID_PERSONA
                JOIN CARGO c   ON c.ID_CARGO=e.ID_CARGO
                ORDER BY e.ESTADO, p.APELLIDOS");
            d.EmpleadosDetalle = det.Select(r => new EmpleadoDetalleItem
            {
                Nombre = (string)r.NOM,
                Cargo = (string)r.CAR,
                Estado = (string)r.ESTADO,
                Salario = Convert.ToDecimal(r.SALARIO),
                FechaIngreso = Convert.ToDateTime(r.FECHA_INGRESO),
                TipoJornada = (string)r.TIPO_JORNADA
            }).ToList();

            return d;
        }

        // ── CONTRATOS ────────────────────────────────────────
        public async Task<DashboardContratosModel> GetDashboardContratosAsync()
        {
            var d = new DashboardContratosModel();

            var kpi = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS TOT,
                       SUM(CASE WHEN ESTADO='ACTIVO' THEN 1 ELSE 0 END) AS AC,
                       SUM(CASE WHEN ESTADO='ACTIVO' AND FECHA_FIN IS NOT NULL
                                AND FECHA_FIN<=SYSDATE+30 THEN 1 ELSE 0 END) AS V30,
                       SUM(CASE WHEN ESTADO='ACTIVO' AND FECHA_FIN IS NOT NULL
                                AND FECHA_FIN>SYSDATE+30 AND FECHA_FIN<=SYSDATE+60 THEN 1 ELSE 0 END) AS V60,
                       SUM(CASE WHEN ESTADO='EN_MORA' THEN 1 ELSE 0 END) AS MO,
                       SUM(CASE WHEN TIPO_CONTRATO='ARRENDAMIENTO' THEN 1 ELSE 0 END) AS ARR,
                       SUM(CASE WHEN TIPO_CONTRATO='VENTA' THEN 1 ELSE 0 END) AS VEN,
                       NVL(SUM(CASE WHEN ESTADO='ACTIVO' THEN MONTO ELSE 0 END),0) AS MTTL
                FROM CONTRATO");
            d.TotalContratos = Convert.ToInt32(kpi?.TOT ?? 0);
            d.ContratosActivos = Convert.ToInt32(kpi?.AC ?? 0);
            d.ContratosVencen30Dias = Convert.ToInt32(kpi?.V30 ?? 0);
            d.ContratosVencen60Dias = Convert.ToInt32(kpi?.V60 ?? 0);
            d.ContratosEnMora = Convert.ToInt32(kpi?.MO ?? 0);
            d.ContratosArrendamiento = Convert.ToInt32(kpi?.ARR ?? 0);
            d.ContratosVenta = Convert.ToInt32(kpi?.VEN ?? 0);
            d.MontoTotalContratos = Convert.ToDecimal(kpi?.MTTL ?? 0);

            var prox = await _db.QueryAsync<dynamic>(@"
                SELECT * FROM (
                    SELECT p.CODIGO AS PROP, per.NOMBRES||' '||per.APELLIDOS AS RES,
                           c.TIPO_CONTRATO, c.FECHA_INICIO, c.FECHA_FIN, c.MONTO, c.ESTADO,
                           CASE WHEN c.FECHA_FIN IS NOT NULL
                                THEN TRUNC(c.FECHA_FIN)-TRUNC(SYSDATE) ELSE 9999 END AS DVEN
                    FROM CONTRATO c
                    JOIN PROPIEDAD p ON p.ID_PROPIEDAD=c.ID_PROPIEDAD
                    JOIN RESIDENTE r ON r.ID_RESIDENTE=c.ID_RESIDENTE
                    JOIN PERSONA per ON per.ID_PERSONA=r.ID_PERSONA
                    WHERE c.ESTADO='ACTIVO' ORDER BY DVEN
                ) WHERE ROWNUM<=20");
            d.ContratosProximos = prox.Select(r => new ContratoVencimientoItem
            {
                Propiedad = (string)r.PROP,
                Residente = (string)r.RES,
                TipoContrato = (string)r.TIPO_CONTRATO,
                FechaFin = r.FECHA_FIN != null ? (DateTime?)Convert.ToDateTime(r.FECHA_FIN) : null,
                DiasParaVencer = Convert.ToInt32(r.DVEN) == 9999 ? -1 : Convert.ToInt32(r.DVEN),
                Monto = Convert.ToDecimal(r.MONTO),
                Estado = (string)r.ESTADO
            }).ToList();

            var tipo = await _db.QueryAsync<dynamic>(@"
                SELECT TIPO_CONTRATO AS TIPO, COUNT(*) AS TOT, NVL(SUM(MONTO),0) AS MTTL
                FROM CONTRATO GROUP BY TIPO_CONTRATO");
            d.DistribucionPorTipo = tipo.Select(r => new ContratoTipoItem
            { Tipo = (string)r.TIPO, Total = Convert.ToInt32(r.TOT), MontoTotal = Convert.ToDecimal(r.MTTL) }).ToList();

            var ren = await _db.QueryAsync<dynamic>(@"
                SELECT p.CODIGO AS PROP, per.NOMBRES||' '||per.APELLIDOS AS RES,
                       rc.MONTO_NUEVO, rc.FECHA_INICIO, rc.ESTADO
                FROM RENOVACION_CONTRATO rc
                JOIN CONTRATO c ON c.ID_CONTRATO=rc.ID_CONTRATO
                JOIN PROPIEDAD p ON p.ID_PROPIEDAD=c.ID_PROPIEDAD
                JOIN RESIDENTE r ON r.ID_RESIDENTE=c.ID_RESIDENTE
                JOIN PERSONA per ON per.ID_PERSONA=r.ID_PERSONA
                WHERE TRUNC(rc.FECHA_REGISTRO,'MM')=TRUNC(SYSDATE,'MM')
                ORDER BY rc.FECHA_REGISTRO DESC");
            d.RenovacionesMes = ren.Select(r => new RenovacionItem
            {
                Propiedad = (string)r.PROP,
                Residente = (string)r.RES,
                MontoNuevo = Convert.ToDecimal(r.MONTO_NUEVO),
                FechaInicio = Convert.ToDateTime(r.FECHA_INICIO),
                Estado = (string)r.ESTADO
            }).ToList();

            return d;
        }

        // ── MULTAS ───────────────────────────────────────────
        public async Task<DashboardMultasModel> GetDashboardMultasAsync()
        {
            var d = new DashboardMultasModel();

            var kpi = await _db.QueryFirstOrDefaultAsync<dynamic>(@"
                SELECT COUNT(*) AS TOT,
                       SUM(CASE WHEN ESTADO='PENDIENTE' THEN 1 ELSE 0 END) AS PE,
                       SUM(CASE WHEN ESTADO='PAGADA'    THEN 1 ELSE 0 END) AS PA,
                       SUM(CASE WHEN ESTADO='APELADA'   THEN 1 ELSE 0 END) AS AP,
                       SUM(CASE WHEN ESTADO='ANULADA'   THEN 1 ELSE 0 END) AS AN,
                       SUM(CASE WHEN ESTADO='EN_MORA'   THEN 1 ELSE 0 END) AS MO,
                       NVL(SUM(CASE WHEN ESTADO IN ('PENDIENTE','EN_MORA') THEN MONTO ELSE 0 END),0) AS MPEND,
                       NVL(SUM(CASE WHEN ESTADO='PAGADA'
                                     AND TRUNC(FECHA_VENCIMIENTO,'MM')=TRUNC(SYSDATE,'MM')
                                    THEN MONTO ELSE 0 END),0) AS MMES
                FROM MULTA");
            d.TotalMultas = Convert.ToInt32(kpi?.TOT ?? 0);
            d.MultasPendientes = Convert.ToInt32(kpi?.PE ?? 0);
            d.MultasPagadas = Convert.ToInt32(kpi?.PA ?? 0);
            d.MultasApeladas = Convert.ToInt32(kpi?.AP ?? 0);
            d.MultasAnuladas = Convert.ToInt32(kpi?.AN ?? 0);
            d.MultasEnMora = Convert.ToInt32(kpi?.MO ?? 0);
            d.MontoPendiente = Convert.ToDecimal(kpi?.MPEND ?? 0);
            d.MontoCobradoMes = Convert.ToDecimal(kpi?.MMES ?? 0);

            var tend = await _db.QueryAsync<dynamic>(@"
                SELECT TO_CHAR(TRUNC(FECHA_INFRACCION,'MM'),'MON-YY') AS MES,
                       TRUNC(FECHA_INFRACCION,'MM') AS FORD,
                       COUNT(*) AS CANT, NVL(SUM(MONTO),0) AS MONT
                FROM MULTA WHERE FECHA_INFRACCION>=ADD_MONTHS(SYSDATE,-6)
                GROUP BY TO_CHAR(TRUNC(FECHA_INFRACCION,'MM'),'MON-YY'),TRUNC(FECHA_INFRACCION,'MM')
                ORDER BY TRUNC(FECHA_INFRACCION,'MM')");
            d.TendenciaMensual = tend.Select(r => new MultaMensualItem
            { Mes = (string)r.MES, Cantidad = Convert.ToInt32(r.CANT), Monto = Convert.ToDecimal(r.MONT) }).ToList();

            var est = await _db.QueryAsync<dynamic>(@"
                SELECT ESTADO, COUNT(*) AS CANT, NVL(SUM(MONTO),0) AS MONT
                FROM MULTA GROUP BY ESTADO ORDER BY CANT DESC");
            d.DistribucionEstado = est.Select(r => new MultaEstadoItem
            { Estado = (string)r.ESTADO, Cantidad = Convert.ToInt32(r.CANT), Monto = Convert.ToDecimal(r.MONT) }).ToList();

            var inf = await _db.QueryAsync<dynamic>(@"
                SELECT * FROM (
                    SELECT p.NOMBRES||' '||p.APELLIDOS AS RES, pr.CODIGO AS PROP,
                           COUNT(*) AS TMUL, NVL(SUM(m.MONTO),0) AS MMTL
                    FROM MULTA m
                    JOIN RESIDENTE r ON r.ID_RESIDENTE=m.ID_RESIDENTE
                    JOIN PERSONA p   ON p.ID_PERSONA=r.ID_PERSONA
                    JOIN PROPIEDAD pr ON pr.ID_PROPIEDAD=m.ID_PROPIEDAD
                    GROUP BY p.NOMBRES,p.APELLIDOS,pr.CODIGO ORDER BY MMTL DESC
                ) WHERE ROWNUM<=10");
            d.TopInfractores = inf.Select(r => new MultaResidenteItem
            {
                Residente = (string)r.RES,
                Propiedad = (string)r.PROP,
                TotalMultas = Convert.ToInt32(r.TMUL),
                MontoTotal = Convert.ToDecimal(r.MMTL)
            }).ToList();

            var rec = await _db.QueryAsync<dynamic>(@"
                SELECT * FROM (
                    SELECT p.NOMBRES||' '||p.APELLIDOS AS RES, pr.CODIGO AS PROP,
                           m.MONTO, m.FECHA_INFRACCION, m.ESTADO
                    FROM MULTA m
                    JOIN RESIDENTE r ON r.ID_RESIDENTE=m.ID_RESIDENTE
                    JOIN PERSONA p   ON p.ID_PERSONA=r.ID_PERSONA
                    JOIN PROPIEDAD pr ON pr.ID_PROPIEDAD=m.ID_PROPIEDAD
                    ORDER BY m.FECHA_REGISTRO DESC
                ) WHERE ROWNUM<=15");
            d.MultasRecientes = rec.Select(r => new MultaDetalleItem
            {
                Residente = (string)r.RES,
                Propiedad = (string)r.PROP,
                Monto = Convert.ToDecimal(r.MONTO),
                FechaInfraccion = Convert.ToDateTime(r.FECHA_INFRACCION),
                Estado = (string)r.ESTADO
            }).ToList();

            return d;
        }
    }
}