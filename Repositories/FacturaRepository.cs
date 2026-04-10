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
                            SERIE                   Serie,
                            NUMERO_FACTURA          NumeroFactura,
                            NUMERO_AUTORIZACION_SAT NumeroAutorizacionSat,
                            ID_PROPIEDAD            IdPropiedad,
                            ID_RESIDENTE            IdResidente,
                            RECEPTOR_NOMBRE         ReceptorNombre,
                            RECEPTOR_NIT            ReceptorNit,
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
                            TOTAL                   Total,
                            SALDO_PENDIENTE         SaldoPendiente,
                            ESTADO                  Estado,
                            ID_CICLO_ORIGEN         IdCicloOrigen,
                            ID_CONTRATO_ORIGEN      IdContratoOrigen,
                            MOTIVO_ANULACION        MotivoAnulacion,
                            GENERADO_POR            GeneradoPor,
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
                            SERIE                   Serie,
                            NUMERO_FACTURA          NumeroFactura,
                            NUMERO_AUTORIZACION_SAT NumeroAutorizacionSat,
                            ID_PROPIEDAD            IdPropiedad,
                            ID_RESIDENTE            IdResidente,
                            RECEPTOR_NOMBRE         ReceptorNombre,
                            RECEPTOR_NIT            ReceptorNit,
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
                            TOTAL                   Total,
                            SALDO_PENDIENTE         SaldoPendiente,
                            ESTADO                  Estado,
                            ID_CICLO_ORIGEN         IdCicloOrigen,
                            ID_CONTRATO_ORIGEN      IdContratoOrigen,
                            MOTIVO_ANULACION        MotivoAnulacion,
                            GENERADO_POR            GeneradoPor,
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
                            SERIE                   Serie,
                            NUMERO_FACTURA          NumeroFactura,
                            NUMERO_AUTORIZACION_SAT NumeroAutorizacionSat,
                            ID_PROPIEDAD            IdPropiedad,
                            ID_RESIDENTE            IdResidente,
                            RECEPTOR_NOMBRE         ReceptorNombre,
                            RECEPTOR_NIT            ReceptorNit,
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
                            TOTAL                   Total,
                            SALDO_PENDIENTE         SaldoPendiente,
                            ESTADO                  Estado,
                            ID_CICLO_ORIGEN         IdCicloOrigen,
                            ID_CONTRATO_ORIGEN      IdContratoOrigen,
                            MOTIVO_ANULACION        MotivoAnulacion,
                            GENERADO_POR            GeneradoPor,
                            OBSERVACIONES           Observaciones
                          FROM FACTURA
                          WHERE ID_PROPIEDAD = :idPropiedad";

            return (await db.QueryAsync<FacturaModel>(query, new { idPropiedad })).ToList();
        }

        public async Task CreateAsync(FacturaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO FACTURA
                          (ID_TIPO_DOC_FISCAL, SERIE, NUMERO_FACTURA, NUMERO_AUTORIZACION_SAT,
                           ID_PROPIEDAD, ID_RESIDENTE, RECEPTOR_NOMBRE, RECEPTOR_NIT,
                           FECHA_EMISION, FECHA_VENCIMIENTO, PERIODO_INICIO, PERIODO_FIN,
                           ID_MONEDA, TIPO_CAMBIO, SUBTOTAL, TOTAL_DESCUENTOS,
                           BASE_IMPONIBLE, TOTAL_IVA, TOTAL, SALDO_PENDIENTE,
                           ESTADO, ID_CICLO_ORIGEN, ID_CONTRATO_ORIGEN,
                           MOTIVO_ANULACION, GENERADO_POR, OBSERVACIONES)
                          VALUES
                          (:IdTipoDocFiscal, :Serie, :NumeroFactura, :NumeroAutorizacionSat,
                           :IdPropiedad, :IdResidente, :ReceptorNombre, :ReceptorNit,
                           :FechaEmision, :FechaVencimiento, :PeriodoInicio, :PeriodoFin,
                           :IdMoneda, :TipoCambio, :Subtotal, :TotalDescuentos,
                           :BaseImponible, :TotalIva, :Total, :SaldoPendiente,
                           :Estado, :IdCicloOrigen, :IdContratoOrigen,
                           :MotivoAnulacion, :GeneradoPor, :Observaciones)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(FacturaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE FACTURA SET
                          ID_TIPO_DOC_FISCAL      = :IdTipoDocFiscal,
                          SERIE                   = :Serie,
                          NUMERO_FACTURA          = :NumeroFactura,
                          NUMERO_AUTORIZACION_SAT = :NumeroAutorizacionSat,
                          ID_PROPIEDAD            = :IdPropiedad,
                          ID_RESIDENTE            = :IdResidente,
                          RECEPTOR_NOMBRE         = :ReceptorNombre,
                          RECEPTOR_NIT            = :ReceptorNit,
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
                          TOTAL                   = :Total,
                          SALDO_PENDIENTE         = :SaldoPendiente,
                          ESTADO                  = :Estado,
                          ID_CICLO_ORIGEN         = :IdCicloOrigen,
                          ID_CONTRATO_ORIGEN      = :IdContratoOrigen,
                          MOTIVO_ANULACION        = :MotivoAnulacion,
                          GENERADO_POR            = :GeneradoPor,
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
    }
}
