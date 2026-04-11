using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public DetalleFacturaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<DetalleFacturaModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_DETALLE            IdDetalle,
                            ID_FACTURA            IdFactura,
                            NUMERO_LINEA          NumeroLinea,
                            ID_TIPO_SERVICIO      IdTipoServicio,
                            DESCRIPCION           Descripcion,
                            CANTIDAD              Cantidad,
                            PRECIO_UNITARIO       PrecioUnitario,
                            DESCUENTO_PORCENTAJE  DescuentoPorcentaje,
                            DESCUENTO_MONTO       DescuentoMonto,
                            SUBTOTAL_BRUTO        SubtotalBruto,
                            SUBTOTAL_NETO         SubtotalNeto,
                            APLICA_IVA            AplicaIva,
                            PORCENTAJE_IVA        PorcentajeIva,
                            MONTO_IVA             MontoIva,
                            TOTAL_LINEA           TotalLinea,
                            PERIODO_INICIO        PeriodoInicio,
                            PERIODO_FIN           PeriodoFin,
                            OBSERVACIONES         Observaciones
                          FROM DETALLE_FACTURA";

            return (await db.QueryAsync<DetalleFacturaModel>(query)).ToList();
        }

        public async Task<DetalleFacturaModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_DETALLE            IdDetalle,
                            ID_FACTURA            IdFactura,
                            NUMERO_LINEA          NumeroLinea,
                            ID_TIPO_SERVICIO      IdTipoServicio,
                            DESCRIPCION           Descripcion,
                            CANTIDAD              Cantidad,
                            PRECIO_UNITARIO       PrecioUnitario,
                            DESCUENTO_PORCENTAJE  DescuentoPorcentaje,
                            DESCUENTO_MONTO       DescuentoMonto,
                            SUBTOTAL_BRUTO        SubtotalBruto,
                            SUBTOTAL_NETO         SubtotalNeto,
                            APLICA_IVA            AplicaIva,
                            PORCENTAJE_IVA        PorcentajeIva,
                            MONTO_IVA             MontoIva,
                            TOTAL_LINEA           TotalLinea,
                            PERIODO_INICIO        PeriodoInicio,
                            PERIODO_FIN           PeriodoFin,
                            OBSERVACIONES         Observaciones
                          FROM DETALLE_FACTURA
                          WHERE ID_DETALLE = :id";

            return await db.QueryFirstOrDefaultAsync<DetalleFacturaModel>(query, new { id });
        }

        public async Task<List<DetalleFacturaModel>> GetByFacturaAsync(int idFactura)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_DETALLE            IdDetalle,
                            ID_FACTURA            IdFactura,
                            NUMERO_LINEA          NumeroLinea,
                            ID_TIPO_SERVICIO      IdTipoServicio,
                            DESCRIPCION           Descripcion,
                            CANTIDAD              Cantidad,
                            PRECIO_UNITARIO       PrecioUnitario,
                            DESCUENTO_PORCENTAJE  DescuentoPorcentaje,
                            DESCUENTO_MONTO       DescuentoMonto,
                            ID_CONCEPTO_DESCUENTO IdConceptoDescuento,
                            SUBTOTAL_BRUTO        SubtotalBruto,
                            SUBTOTAL_NETO         SubtotalNeto,
                            APLICA_IVA            AplicaIva,
                            PORCENTAJE_IVA        PorcentajeIva,
                            MONTO_IVA             MontoIva,
                            TOTAL_LINEA           TotalLinea,
                            PERIODO_INICIO        PeriodoInicio,
                            PERIODO_FIN           PeriodoFin,
                            OBSERVACIONES         Observaciones
                          FROM DETALLE_FACTURA
                          WHERE ID_FACTURA = :idFactura
                          ORDER BY NUMERO_LINEA";

            return (await db.QueryAsync<DetalleFacturaModel>(query, new { idFactura })).ToList();
        }

        public async Task CreateAsync(DetalleFacturaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO DETALLE_FACTURA
                          (ID_FACTURA, NUMERO_LINEA, ID_TIPO_SERVICIO, DESCRIPCION,
                           CANTIDAD, PRECIO_UNITARIO, DESCUENTO_PORCENTAJE, DESCUENTO_MONTO,
                           SUBTOTAL_BRUTO, SUBTOTAL_NETO, APLICA_IVA, PORCENTAJE_IVA,
                           MONTO_IVA, TOTAL_LINEA, PERIODO_INICIO, PERIODO_FIN, OBSERVACIONES)
                          VALUES
                          (:IdFactura, :NumeroLinea, :IdTipoServicio, :Descripcion,
                           :Cantidad, :PrecioUnitario, :DescuentoPorcentaje, :DescuentoMonto,
                           :SubtotalBruto, :SubtotalNeto, :AplicaIva, :PorcentajeIva,
                           :MontoIva, :TotalLinea, :PeriodoInicio, :PeriodoFin, :Observaciones)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(DetalleFacturaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE DETALLE_FACTURA SET
                          ID_FACTURA           = :IdFactura,
                          NUMERO_LINEA         = :NumeroLinea,
                          ID_TIPO_SERVICIO     = :IdTipoServicio,
                          DESCRIPCION          = :Descripcion,
                          CANTIDAD             = :Cantidad,
                          PRECIO_UNITARIO      = :PrecioUnitario,
                          DESCUENTO_PORCENTAJE = :DescuentoPorcentaje,
                          DESCUENTO_MONTO      = :DescuentoMonto,
                          SUBTOTAL_BRUTO       = :SubtotalBruto,
                          SUBTOTAL_NETO        = :SubtotalNeto,
                          APLICA_IVA           = :AplicaIva,
                          PORCENTAJE_IVA       = :PorcentajeIva,
                          MONTO_IVA            = :MontoIva,
                          TOTAL_LINEA          = :TotalLinea,
                          PERIODO_INICIO       = :PeriodoInicio,
                          PERIODO_FIN          = :PeriodoFin,
                          OBSERVACIONES        = :Observaciones
                          WHERE ID_DETALLE = :IdDetalle";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM DETALLE_FACTURA WHERE ID_DETALLE = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}
