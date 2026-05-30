using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public FacturaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<FacturaModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_FACTURA              IdFactura,
                            ID_TIPO_DOC_FISCAL      IdTipoDocFiscal,
                            ID_CORRELATIVO          IdCorrelativo,
                            SERIE                   Serie,
                            NUMERO_FACTURA          NumeroFactura,
                            NUMERO_AUTORIZACION_SAT NumeroAutorizacionSat,
                            ID_PROPIEDAD            IdPropiedad,
                            ID_RESIDENTE            IdResidente,
                            RECEPTOR_NOMBRE         ReceptorNombre,
                            RECEPTOR_NIT            ReceptorNit,
                            RECEPTOR_DIRECCION      ReceptorDireccion,
                            FECHA_EMISION           FechaEmision,
                            FECHA_VENCIMIENTO       FechaVencimiento,
                            PERIODO_INICIO          PeriodoInicio,
                            PERIODO_FIN             PeriodoFin,
                            ID_MONEDA               IdMoneda,
                            TIPO_CAMBIO             TipoCambio,
                            SUBTOTAL                Subtotal,
                            TOTAL_DESCUENTOS        TotalDescuentos,
                            BASE_IMPONIBLE          BaseImponible,
                            TOTAL_IVA               TotalIva,
                            TOTAL_OTROS_IMPUESTOS   TotalOtrosImpuestos,
                            TOTAL                   Total,
                            TOTAL_EN_LETRAS         TotalEnLetras,
                            SALDO_PENDIENTE         SaldoPendiente,
                            ESTADO                  Estado,
                            ID_CICLO_ORIGEN         IdCicloOrigen,
                            ID_CONTRATO_ORIGEN      IdContratoOrigen,
                            ID_RESERVA_ORIGEN       IdReservaOrigen,
                            ID_FACTURA_ORIGEN       IdFacturaOrigen,
                            MOTIVO_ANULACION        MotivoAnulacion,
                            GENERADO_POR            GeneradoPor,
                            APROBADO_POR            AprobadoPor,
                            OBSERVACIONES           Observaciones
                          FROM FACTURA";

            return (await db.QueryAsync<FacturaModel>(query)).ToList();
        }

        public async Task<FacturaModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_FACTURA              IdFactura,
                            ID_TIPO_DOC_FISCAL      IdTipoDocFiscal,
                            ID_CORRELATIVO          IdCorrelativo,
                            SERIE                   Serie,
                            NUMERO_FACTURA          NumeroFactura,
                            NUMERO_AUTORIZACION_SAT NumeroAutorizacionSat,
                            ID_PROPIEDAD            IdPropiedad,
                            ID_RESIDENTE            IdResidente,
                            RECEPTOR_NOMBRE         ReceptorNombre,
                            RECEPTOR_NIT            ReceptorNit,
                            RECEPTOR_DIRECCION      ReceptorDireccion,
                            FECHA_EMISION           FechaEmision,
                            FECHA_VENCIMIENTO       FechaVencimiento,
                            PERIODO_INICIO          PeriodoInicio,
                            PERIODO_FIN             PeriodoFin,
                            ID_MONEDA               IdMoneda,
                            TIPO_CAMBIO             TipoCambio,
                            SUBTOTAL                Subtotal,
                            TOTAL_DESCUENTOS        TotalDescuentos,
                            BASE_IMPONIBLE          BaseImponible,
                            TOTAL_IVA               TotalIva,
                            TOTAL_OTROS_IMPUESTOS   TotalOtrosImpuestos,
                            TOTAL                   Total,
                            TOTAL_EN_LETRAS         TotalEnLetras,
                            SALDO_PENDIENTE         SaldoPendiente,
                            ESTADO                  Estado,
                            ID_CICLO_ORIGEN         IdCicloOrigen,
                            ID_CONTRATO_ORIGEN      IdContratoOrigen,
                            ID_RESERVA_ORIGEN       IdReservaOrigen,
                            ID_FACTURA_ORIGEN       IdFacturaOrigen,
                            MOTIVO_ANULACION        MotivoAnulacion,
                            GENERADO_POR            GeneradoPor,
                            APROBADO_POR            AprobadoPor,
                            OBSERVACIONES           Observaciones
                          FROM FACTURA
                          WHERE ID_FACTURA = :id";

            return await db.QueryFirstOrDefaultAsync<FacturaModel>(query, new { id });
        }

        public async Task<List<FacturaModel>> GetByPropiedadAsync(int idPropiedad)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_FACTURA              IdFactura,
                            ID_TIPO_DOC_FISCAL      IdTipoDocFiscal,
                            ID_CORRELATIVO          IdCorrelativo,
                            SERIE                   Serie,
                            NUMERO_FACTURA          NumeroFactura,
                            NUMERO_AUTORIZACION_SAT NumeroAutorizacionSat,
                            ID_PROPIEDAD            IdPropiedad,
                            ID_RESIDENTE            IdResidente,
                            RECEPTOR_NOMBRE         ReceptorNombre,
                            RECEPTOR_NIT            ReceptorNit,
                            RECEPTOR_DIRECCION      ReceptorDireccion,
                            FECHA_EMISION           FechaEmision,
                            FECHA_VENCIMIENTO       FechaVencimiento,
                            PERIODO_INICIO          PeriodoInicio,
                            PERIODO_FIN             PeriodoFin,
                            ID_MONEDA               IdMoneda,
                            TIPO_CAMBIO             TipoCambio,
                            SUBTOTAL                Subtotal,
                            TOTAL_DESCUENTOS        TotalDescuentos,
                            BASE_IMPONIBLE          BaseImponible,
                            TOTAL_IVA               TotalIva,
                            TOTAL_OTROS_IMPUESTOS   TotalOtrosImpuestos,
                            TOTAL                   Total,
                            TOTAL_EN_LETRAS         TotalEnLetras,
                            SALDO_PENDIENTE         SaldoPendiente,
                            ESTADO                  Estado,
                            ID_CICLO_ORIGEN         IdCicloOrigen,
                            ID_CONTRATO_ORIGEN      IdContratoOrigen,
                            ID_RESERVA_ORIGEN       IdReservaOrigen,
                            ID_FACTURA_ORIGEN       IdFacturaOrigen,
                            MOTIVO_ANULACION        MotivoAnulacion,
                            GENERADO_POR            GeneradoPor,
                            APROBADO_POR            AprobadoPor,
                            OBSERVACIONES           Observaciones
                          FROM FACTURA
                          WHERE ID_PROPIEDAD = :idPropiedad";

            return (await db.QueryAsync<FacturaModel>(query, new { idPropiedad })).ToList();
        }

        public async Task<int> CreateAsync(FacturaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO FACTURA
                          (ID_TIPO_DOC_FISCAL, ID_CORRELATIVO, SERIE, NUMERO_FACTURA, NUMERO_AUTORIZACION_SAT,
                           ID_PROPIEDAD, ID_RESIDENTE, RECEPTOR_NOMBRE, RECEPTOR_NIT, RECEPTOR_DIRECCION,
                           FECHA_EMISION, FECHA_VENCIMIENTO, PERIODO_INICIO, PERIODO_FIN,
                           ID_MONEDA, TIPO_CAMBIO, SUBTOTAL, TOTAL_DESCUENTOS,
                           BASE_IMPONIBLE, TOTAL_IVA, TOTAL_OTROS_IMPUESTOS, TOTAL, TOTAL_EN_LETRAS, SALDO_PENDIENTE,
                           ESTADO, ID_CICLO_ORIGEN, ID_CONTRATO_ORIGEN, ID_RESERVA_ORIGEN, ID_FACTURA_ORIGEN,
                           MOTIVO_ANULACION, GENERADO_POR, APROBADO_POR, OBSERVACIONES)
                          VALUES
                          (:IdTipoDocFiscal, :IdCorrelativo, :Serie, :NumeroFactura, :NumeroAutorizacionSat,
                           :IdPropiedad, :IdResidente, :ReceptorNombre, :ReceptorNit, :ReceptorDireccion,
                           :FechaEmision, :FechaVencimiento, :PeriodoInicio, :PeriodoFin,
                           :IdMoneda, :TipoCambio, :Subtotal, :TotalDescuentos,
                           :BaseImponible, :TotalIva, :TotalOtrosImpuestos, :Total, :TotalEnLetras, :SaldoPendiente,
                           :Estado, :IdCicloOrigen, :IdContratoOrigen, :IdReservaOrigen, :IdFacturaOrigen,
                           :MotivoAnulacion, :GeneradoPor, :AprobadoPor, :Observaciones)";

            await db.ExecuteAsync(query, model);

            // Obtener el ID generado usando el número de factura (único)
            var newId = await db.ExecuteScalarAsync<int>(
                "SELECT ID_FACTURA FROM FACTURA WHERE NUMERO_FACTURA = :NumeroFactura AND ID_CORRELATIVO = :IdCorrelativo",
                new { model.NumeroFactura, model.IdCorrelativo });

            return newId;
        }

        public async Task UpdateAsync(FacturaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE FACTURA SET
                          ID_TIPO_DOC_FISCAL      = :IdTipoDocFiscal,
                          ID_CORRELATIVO          = :IdCorrelativo,
                          SERIE                   = :Serie,
                          NUMERO_FACTURA          = :NumeroFactura,
                          NUMERO_AUTORIZACION_SAT = :NumeroAutorizacionSat,
                          ID_PROPIEDAD            = :IdPropiedad,
                          ID_RESIDENTE            = :IdResidente,
                          RECEPTOR_NOMBRE         = :ReceptorNombre,
                          RECEPTOR_NIT            = :ReceptorNit,
                          RECEPTOR_DIRECCION      = :ReceptorDireccion,
                          FECHA_EMISION           = :FechaEmision,
                          FECHA_VENCIMIENTO       = :FechaVencimiento,
                          PERIODO_INICIO          = :PeriodoInicio,
                          PERIODO_FIN             = :PeriodoFin,
                          ID_MONEDA               = :IdMoneda,
                          TIPO_CAMBIO             = :TipoCambio,
                          SUBTOTAL                = :Subtotal,
                          TOTAL_DESCUENTOS        = :TotalDescuentos,
                          BASE_IMPONIBLE          = :BaseImponible,
                          TOTAL_IVA               = :TotalIva,
                          TOTAL_OTROS_IMPUESTOS   = :TotalOtrosImpuestos,
                          TOTAL                   = :Total,
                          TOTAL_EN_LETRAS         = :TotalEnLetras,
                          SALDO_PENDIENTE         = :SaldoPendiente,
                          ESTADO                  = :Estado,
                          ID_CICLO_ORIGEN         = :IdCicloOrigen,
                          ID_CONTRATO_ORIGEN      = :IdContratoOrigen,
                          ID_RESERVA_ORIGEN       = :IdReservaOrigen,
                          ID_FACTURA_ORIGEN       = :IdFacturaOrigen,
                          MOTIVO_ANULACION        = :MotivoAnulacion,
                          GENERADO_POR            = :GeneradoPor,
                          APROBADO_POR            = :AprobadoPor,
                          OBSERVACIONES           = :Observaciones
                          WHERE ID_FACTURA = :IdFactura";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM FACTURA WHERE ID_FACTURA = :id";

            await db.ExecuteAsync(query, new { id });
        }

        public async Task<int> GetNextCorrelativeAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT COALESCE(MAX(ID_CORRELATIVO), 0) + 1 as NextCorrelative 
                         FROM FACTURA";

            var result = await db.QueryFirstOrDefaultAsync<int>(query);
            return result;
        }
    }
}
