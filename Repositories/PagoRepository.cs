using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public PagoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<PagoModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_PAGO          IdPago,
                            ID_FACTURA       IdFactura,
                            NUMERO_RECIBO    NumeroRecibo,
                            FECHA_PAGO       FechaPago,
                            FECHA_VALOR      FechaValor,
                            MONTO_PAGADO     MontoPagado,
                            ID_MONEDA        IdMoneda,
                            TIPO_CAMBIO      TipoCambio,
                            MONTO_EN_GTQ     MontoEnGtq,
                            ID_METODO_PAGO   IdMetodoPago,
                            ID_BANCO_ORIGEN  IdBancoOrigen,
                            ID_BANCO_DESTINO IdBancoDestino,
                            REFERENCIA       Referencia,
                            IMAGEN_VOUCHER_URL ImagenVoucherUrl,
                            ESTADO           Estado,
                            REGISTRADO_POR   RegistradoPor,
                            APROBADO_POR     AprobadoPor,
                            OBSERVACIONES    Observaciones
                          FROM PAGO";

            return (await db.QueryAsync<PagoModel>(query)).ToList();
        }

        public async Task<PagoModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_PAGO          IdPago,
                            ID_FACTURA       IdFactura,
                            NUMERO_RECIBO    NumeroRecibo,
                            FECHA_PAGO       FechaPago,
                            FECHA_VALOR      FechaValor,
                            MONTO_PAGADO     MontoPagado,
                            ID_MONEDA        IdMoneda,
                            TIPO_CAMBIO      TipoCambio,
                            MONTO_EN_GTQ     MontoEnGtq,
                            ID_METODO_PAGO   IdMetodoPago,
                            ID_BANCO_ORIGEN  IdBancoOrigen,
                            ID_BANCO_DESTINO IdBancoDestino,
                            REFERENCIA       Referencia,
                            IMAGEN_VOUCHER_URL ImagenVoucherUrl,
                            ESTADO           Estado,
                            REGISTRADO_POR   RegistradoPor,
                            APROBADO_POR     AprobadoPor,
                            OBSERVACIONES    Observaciones
                          FROM PAGO
                          WHERE ID_PAGO = :id";

            return await db.QueryFirstOrDefaultAsync<PagoModel>(query, new { id });
        }

        public async Task<List<PagoModel>> GetByFacturaAsync(int idFactura)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_PAGO          IdPago,
                            ID_FACTURA       IdFactura,
                            NUMERO_RECIBO    NumeroRecibo,
                            FECHA_PAGO       FechaPago,
                            FECHA_VALOR      FechaValor,
                            MONTO_PAGADO     MontoPagado,
                            ID_MONEDA        IdMoneda,
                            TIPO_CAMBIO      TipoCambio,
                            MONTO_EN_GTQ     MontoEnGtq,
                            ID_METODO_PAGO   IdMetodoPago,
                            ID_BANCO_ORIGEN  IdBancoOrigen,
                            ID_BANCO_DESTINO IdBancoDestino,
                            REFERENCIA       Referencia,
                            IMAGEN_VOUCHER_URL ImagenVoucherUrl,
                            ESTADO           Estado,
                            REGISTRADO_POR   RegistradoPor,
                            APROBADO_POR     AprobadoPor,
                            OBSERVACIONES    Observaciones
                          FROM PAGO
                          WHERE ID_FACTURA = :idFactura";

            return (await db.QueryAsync<PagoModel>(query, new { idFactura })).ToList();
        }

        public async Task CreateAsync(PagoModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO PAGO
                          (ID_FACTURA, NUMERO_RECIBO, FECHA_PAGO, FECHA_VALOR,
                           MONTO_PAGADO, ID_MONEDA, TIPO_CAMBIO, MONTO_EN_GTQ,
                           ID_METODO_PAGO, ID_BANCO_ORIGEN, ID_BANCO_DESTINO,
                           REFERENCIA, IMAGEN_VOUCHER_URL, ESTADO,
                           REGISTRADO_POR, APROBADO_POR, OBSERVACIONES)
                          VALUES
                          (:IdFactura, :NumeroRecibo, :FechaPago, :FechaValor,
                           :MontoPagado, :IdMoneda, :TipoCambio, :MontoEnGtq,
                           :IdMetodoPago, :IdBancoOrigen, :IdBancoDestino,
                           :Referencia, :ImagenVoucherUrl, :Estado,
                           :RegistradoPor, :AprobadoPor, :Observaciones)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(PagoModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE PAGO SET
                          ID_FACTURA       = :IdFactura,
                          NUMERO_RECIBO    = :NumeroRecibo,
                          FECHA_PAGO       = :FechaPago,
                          FECHA_VALOR      = :FechaValor,
                          MONTO_PAGADO     = :MontoPagado,
                          ID_MONEDA        = :IdMoneda,
                          TIPO_CAMBIO      = :TipoCambio,
                          MONTO_EN_GTQ     = :MontoEnGtq,
                          ID_METODO_PAGO   = :IdMetodoPago,
                          ID_BANCO_ORIGEN  = :IdBancoOrigen,
                          ID_BANCO_DESTINO = :IdBancoDestino,
                          REFERENCIA       = :Referencia,
                          IMAGEN_VOUCHER_URL = :ImagenVoucherUrl,
                          ESTADO           = :Estado,
                          REGISTRADO_POR   = :RegistradoPor,
                          APROBADO_POR     = :AprobadoPor,
                          OBSERVACIONES    = :Observaciones
                          WHERE ID_PAGO = :IdPago";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM PAGO WHERE ID_PAGO = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}
