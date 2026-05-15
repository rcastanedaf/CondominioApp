namespace Condominio.Models
{
    // ── DASHBOARD GENERAL (existente sin cambios) ────────────
    public class DashboardModel
    {
        public int TotalResidentes { get; set; }
        public int ResidentesActivos { get; set; }
        public int ResidentesInactivos { get; set; }
        public decimal TotalCobradoMes { get; set; }
        public decimal TotalPendienteCobro { get; set; }
        public decimal TotalMora { get; set; }
        public int FacturasPendientes { get; set; }
        public int FacturasVencidas { get; set; }
        public int IncidenciasAbiertas { get; set; }
        public int IncidenciasEnProceso { get; set; }
        public int IncidenciasCerradasMes { get; set; }
        public int AccesosHoy { get; set; }
        public int VisitasHoy { get; set; }
        public int ReservasHoy { get; set; }
        public int EspaciosDisponibles { get; set; }
        public int TotalEmpleados { get; set; }
        public int EmpleadosActivos { get; set; }
        public int MultasPendientes { get; set; }
        public decimal MontoMultasPendientes { get; set; }
        public List<PagoMensualItem> PagosPorMes { get; set; } = new();
        public List<IncidenciaPorCategoriaItem> IncidenciasPorCategoria { get; set; } = new();
        public List<MorososItem> TopMorosos { get; set; } = new();
    }
    public class PagoMensualItem
    {
        public string Mes { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
    public class IncidenciaPorCategoriaItem
    {
        public string Categoria { get; set; } = string.Empty;
        public int Total { get; set; }
    }
    public class MorososItem
    {
        public string Residente { get; set; } = string.Empty;
        public decimal MontoPendiente { get; set; }
        public int DiasAtraso { get; set; }
    }

    // ── DASHBOARD FINANCIERO ─────────────────────────────────
    public class DashboardFinancieroModel
    {
        public decimal TotalCobradoMes { get; set; }
        public decimal TotalCobradoAnio { get; set; }
        public decimal TotalPendiente { get; set; }
        public decimal TotalMora { get; set; }
        public decimal TotalSaldosAFavor { get; set; }
        public int FacturasPendientes { get; set; }
        public int FacturasVencidas { get; set; }
        public int AcuerdosPagoActivos { get; set; }
        public decimal PromedioMoraDias { get; set; }
        public List<IngresoMensualItem> IngresosPorMes { get; set; } = new();
        public List<CarteraItem> DistribucionCartera { get; set; } = new();
        public List<MetodoPagoItem> PagosPorMetodo { get; set; } = new();
        public List<MorososItem> TopMorosos { get; set; } = new();
        public List<ServicioIngresosItem> IngresosPorServicio { get; set; } = new();
    }
    public class IngresoMensualItem
    {
        public string Mes { get; set; } = string.Empty;
        public decimal TotalIngresos { get; set; }
        public int NumPagos { get; set; }
    }
    public class CarteraItem
    {
        public string Estado { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public int Cantidad { get; set; }
    }
    public class MetodoPagoItem
    {
        public string Metodo { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public int Cantidad { get; set; }
    }
    public class ServicioIngresosItem
    {
        public string Servicio { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }

    // ── DASHBOARD RESIDENTES ─────────────────────────────────
    public class DashboardResidentesModel
    {
        public int TotalPropiedades { get; set; }
        public int PropiedadesOcupadas { get; set; }
        public int PropiedadesDisponibles { get; set; }
        public int PropiedadesMantenimiento { get; set; }
        public int TotalResidentes { get; set; }
        public int Propietarios { get; set; }
        public int Inquilinos { get; set; }
        public int TotalVehiculos { get; set; }
        public int TotalFamiliares { get; set; }
        public List<TipoPropiedadItem> PropiedadesPorTipo { get; set; } = new();
        public List<OcupacionMensualItem> OcupacionHistorica { get; set; } = new();
        public List<ResidenteDetalleItem> ResidentesDetalle { get; set; } = new();
    }
    public class TipoPropiedadItem
    {
        public string Tipo { get; set; } = string.Empty;
        public int Total { get; set; }
        public int Ocupadas { get; set; }
    }
    public class OcupacionMensualItem
    {
        public string Mes { get; set; } = string.Empty;
        public int Ingresos { get; set; }
    }
    public class ResidenteDetalleItem
    {
        public string Nombre { get; set; } = string.Empty;
        public string Propiedad { get; set; } = string.Empty;
        public string TipoResidente { get; set; } = string.Empty;
        public DateTime FechaIngreso { get; set; }
        public int NumFamiliares { get; set; }
        public int NumVehiculos { get; set; }
    }

    // ── DASHBOARD ACCESO ─────────────────────────────────────
    public class DashboardAccesoModel
    {
        public int AccesosHoy { get; set; }
        public int VisitasHoy { get; set; }
        public int EntradasHoy { get; set; }
        public int SalidasHoy { get; set; }
        public int PersonasEnLista { get; set; }
        public int VehiculosEnLista { get; set; }
        public int VisitasActivasHoy { get; set; }
        public List<AccesoDiarioItem> AccesosPorDia { get; set; } = new();
        public List<TipoPersonaAccesoItem> AccesosPorTipo { get; set; } = new();
        public List<HoraAccesoItem> AccesosPorHora { get; set; } = new();
        public List<ListaNegraItem> ListaNegra { get; set; } = new();
    }
    public class AccesoDiarioItem
    {
        public string Fecha { get; set; } = string.Empty;
        public int Entradas { get; set; }
        public int Salidas { get; set; }
        public int Total { get; set; }
    }
    public class TipoPersonaAccesoItem
    {
        public string TipoPersona { get; set; } = string.Empty;
        public int Total { get; set; }
    }
    public class HoraAccesoItem
    {
        public int Hora { get; set; }
        public int Total { get; set; }
    }
    public class ListaNegraItem
    {
        public string Tipo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Motivo { get; set; } = string.Empty;
        public DateTime? FechaFin { get; set; }
    }

    // ── DASHBOARD INCIDENCIAS ────────────────────────────────
    public class DashboardIncidenciasModel
    {
        public int TotalAbiertas { get; set; }
        public int TotalEnProceso { get; set; }
        public int TotalResueltas { get; set; }
        public int TotalAlta { get; set; }
        public int TotalMedia { get; set; }
        public int TotalBaja { get; set; }
        public decimal CostoEstimadoTotal { get; set; }
        public decimal CostoRealTotal { get; set; }
        public double PromedioHorasResolucion { get; set; }
        public List<IncidenciaCategoriaDetalle> PorCategoria { get; set; } = new();
        public List<IncidenciaTendenciaItem> TendenciaMensual { get; set; } = new();
        public List<IncidenciaDetalleItem> IncidenciasRecientes { get; set; } = new();
    }
    public class IncidenciaCategoriaDetalle
    {
        public string Categoria { get; set; } = string.Empty;
        public int Abiertas { get; set; }
        public int EnProceso { get; set; }
        public int Resueltas { get; set; }
        public int Alta { get; set; }
        public int Media { get; set; }
        public int Baja { get; set; }
    }
    public class IncidenciaTendenciaItem
    {
        public string Mes { get; set; } = string.Empty;
        public int Abiertas { get; set; }
        public int Resueltas { get; set; }
    }
    public class IncidenciaDetalleItem
    {
        public string Titulo { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Prioridad { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaApertura { get; set; }
        public string Propiedad { get; set; } = string.Empty;
    }

    // ── DASHBOARD ESPACIOS ───────────────────────────────────
    public class DashboardEspaciosModel
    {
        public int TotalEspacios { get; set; }
        public int EspaciosDisponibles { get; set; }
        public int EspaciosMantenimiento { get; set; }
        public int ReservasHoy { get; set; }
        public int ReservasMes { get; set; }
        public decimal IngresosReservasMes { get; set; }
        public decimal DepositosPendientesDevolucion { get; set; }
        public List<EspacioReservaItem> ReservasPorEspacio { get; set; } = new();
        public List<ReservaTendenciaItem> TendenciaMensual { get; set; } = new();
        public List<ReservaDetalleItem> ProximasReservas { get; set; } = new();
    }
    public class EspacioReservaItem
    {
        public string Espacio { get; set; } = string.Empty;
        public int TotalReservas { get; set; }
        public int Aprobadas { get; set; }
        public int Pendientes { get; set; }
        public decimal Ingresos { get; set; }
    }
    public class ReservaTendenciaItem
    {
        public string Mes { get; set; } = string.Empty;
        public int TotalReservas { get; set; }
        public decimal Ingresos { get; set; }
    }
    public class ReservaDetalleItem
    {
        public string Espacio { get; set; } = string.Empty;
        public string Residente { get; set; } = string.Empty;
        public string Propiedad { get; set; } = string.Empty;
        public DateTime FechaReserva { get; set; }
        public string HoraInicio { get; set; } = string.Empty;
        public string HoraFin { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }

    // ── DASHBOARD PERSONAL ───────────────────────────────────
    public class DashboardPersonalModel
    {
        public int TotalEmpleados { get; set; }
        public int EmpleadosActivos { get; set; }
        public int EmpleadosSuspendidos { get; set; }
        public int EmpleadosBaja { get; set; }
        public decimal TotalNominaActual { get; set; }
        public int PresentesHoy { get; set; }
        public int AusentesHoy { get; set; }
        public int TardesHoy { get; set; }
        public List<EmpleadoCargoDist> DistribucionPorCargo { get; set; } = new();
        public List<AsistenciaResumenItem> AsistenciaMes { get; set; } = new();
        public List<EmpleadoDetalleItem> EmpleadosDetalle { get; set; } = new();
    }
    public class EmpleadoCargoDist
    {
        public string Cargo { get; set; } = string.Empty;
        public int Total { get; set; }
        public decimal SalarioPromedio { get; set; }
    }
    public class AsistenciaResumenItem
    {
        public string Empleado { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public int Presentes { get; set; }
        public int Tardanzas { get; set; }
        public int Ausentes { get; set; }
        public int Permisos { get; set; }
        public int MinutosExtra { get; set; }
    }
    public class EmpleadoDetalleItem
    {
        public string Nombre { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoJornada { get; set; } = string.Empty;
    }

    // ── DASHBOARD CONTRATOS ──────────────────────────────────
    public class DashboardContratosModel
    {
        public int TotalContratos { get; set; }
        public int ContratosActivos { get; set; }
        public int ContratosVencen30Dias { get; set; }
        public int ContratosVencen60Dias { get; set; }
        public int ContratosEnMora { get; set; }
        public int ContratosArrendamiento { get; set; }
        public int ContratosVenta { get; set; }
        public decimal MontoTotalContratos { get; set; }
        public List<ContratoVencimientoItem> ContratosProximos { get; set; } = new();
        public List<ContratoTipoItem> DistribucionPorTipo { get; set; } = new();
        public List<RenovacionItem> RenovacionesMes { get; set; } = new();
    }
    public class ContratoVencimientoItem
    {
        public string Propiedad { get; set; } = string.Empty;
        public string Residente { get; set; } = string.Empty;
        public string TipoContrato { get; set; } = string.Empty;
        public DateTime? FechaFin { get; set; }
        public int DiasParaVencer { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
    public class ContratoTipoItem
    {
        public string Tipo { get; set; } = string.Empty;
        public int Total { get; set; }
        public decimal MontoTotal { get; set; }
    }
    public class RenovacionItem
    {
        public string Propiedad { get; set; } = string.Empty;
        public string Residente { get; set; } = string.Empty;
        public decimal MontoNuevo { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Estado { get; set; } = string.Empty;
    }

    // ── DASHBOARD MULTAS ─────────────────────────────────────
    public class DashboardMultasModel
    {
        public int TotalMultas { get; set; }
        public int MultasPendientes { get; set; }
        public int MultasPagadas { get; set; }
        public int MultasApeladas { get; set; }
        public int MultasAnuladas { get; set; }
        public int MultasEnMora { get; set; }
        public decimal MontoPendiente { get; set; }
        public decimal MontoCobradoMes { get; set; }
        public List<MultaMensualItem> TendenciaMensual { get; set; } = new();
        public List<MultaEstadoItem> DistribucionEstado { get; set; } = new();
        public List<MultaResidenteItem> TopInfractores { get; set; } = new();
        public List<MultaDetalleItem> MultasRecientes { get; set; } = new();
    }
    public class MultaMensualItem
    {
        public string Mes { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }
    }
    public class MultaEstadoItem
    {
        public string Estado { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }
    }
    public class MultaResidenteItem
    {
        public string Residente { get; set; } = string.Empty;
        public string Propiedad { get; set; } = string.Empty;
        public int TotalMultas { get; set; }
        public decimal MontoTotal { get; set; }
    }
    public class MultaDetalleItem
    {
        public string Residente { get; set; } = string.Empty;
        public string Propiedad { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime FechaInfraccion { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}