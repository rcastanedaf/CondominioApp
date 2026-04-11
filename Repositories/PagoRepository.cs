using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Connections;
using Oracle.ManagedDataAccess.Client;
using System.Data;

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

        public async Task<List<PagoModel>> GetByResidenteAsync(int idResidente)
                {
                    using IDbConnection db = new OracleConnection(_stringConnection);
                    var sql = @"
                SELECT 
                    p.id_pago          AS IdPago,
                    p.id_factura       AS IdFactura,
                    p.numero_recibo    AS NumeroRecibo,
                    p.fecha_pago       AS FechaPago,
                    p.fecha_valor      AS FechaValor,
                    p.monto_pagado     AS MontoPagado,
                    p.id_moneda        AS IdMoneda,
                    p.tipo_cambio      AS TipoCambio,
                    p.monto_en_gtq     AS MontoEnGtq,
                    p.id_metodo_pago   AS IdMetodoPago,
                    p.id_banco_origen  AS IdBancoOrigen,
                    p.id_banco_destino AS IdBancoDestino,
                    p.referencia       AS Referencia,
                    p.imagen_voucher_url AS ImagenVoucherUrl,
                    p.estado           AS Estado,
                    p.registrado_por   AS RegistradoPor,
                    p.aprobado_por     AS AprobadoPor,
                    p.observaciones    AS Observaciones
                FROM pago p
                INNER JOIN factura f ON p.id_factura = f.id_factura
                WHERE f.id_residente = :idResidente
                ORDER BY p.fecha_pago DESC";

                    var result = await db.QueryAsync<PagoModel>(sql, new { idResidente });
                    return result.ToList();
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
