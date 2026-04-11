using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class CuentaPorCobrarRepository : ICuentaPorCobrarRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public CuentaPorCobrarRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<CuentaPorCobrarModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_CUENTA              IdCuenta,
                            ID_RESIDENTE           IdResidente,
                            ID_FACTURA             IdFactura,
                            MONTO_ORIGINAL         MontoOriginal,
                            MONTO_PAGADO           MontoPagado,
                            MONTO_MORA             MontoMora,
                            MONTO_PENDIENTE        MontoPendiente,
                            DIAS_ATRASO            DiasAtraso,
                            ESTADO                 Estado,
                            ULTIMA_ACTUALIZACION   UltimaActualizacion
                          FROM CUENTA_POR_COBRAR";

            return (await db.QueryAsync<CuentaPorCobrarModel>(query)).ToList();
        }

        public async Task<CuentaPorCobrarModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_CUENTA              IdCuenta,
                            ID_RESIDENTE           IdResidente,
                            ID_FACTURA             IdFactura,
                            MONTO_ORIGINAL         MontoOriginal,
                            MONTO_PAGADO           MontoPagado,
                            MONTO_MORA             MontoMora,
                            MONTO_PENDIENTE        MontoPendiente,
                            DIAS_ATRASO            DiasAtraso,
                            ESTADO                 Estado,
                            ULTIMA_ACTUALIZACION   UltimaActualizacion
                          FROM CUENTA_POR_COBRAR
                          WHERE ID_CUENTA = :id";

            return await db.QueryFirstOrDefaultAsync<CuentaPorCobrarModel>(query, new { id });
        }

        public async Task<List<CuentaPorCobrarModel>> GetByResidenteAsync(int idResidente)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_CUENTA              IdCuenta,
                            ID_RESIDENTE           IdResidente,
                            ID_FACTURA             IdFactura,
                            MONTO_ORIGINAL         MontoOriginal,
                            MONTO_PAGADO           MontoPagado,
                            MONTO_MORA             MontoMora,
                            MONTO_PENDIENTE        MontoPendiente,
                            DIAS_ATRASO            DiasAtraso,
                            ESTADO                 Estado,
                            ULTIMA_ACTUALIZACION   UltimaActualizacion
                          FROM CUENTA_POR_COBRAR
                          WHERE ID_RESIDENTE = :idResidente
                          ORDER BY DIAS_ATRASO DESC";

            return (await db.QueryAsync<CuentaPorCobrarModel>(query, new { idResidente })).ToList();
        }

        public async Task CreateAsync(CuentaPorCobrarModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO CUENTA_POR_COBRAR
                          (ID_RESIDENTE, ID_FACTURA, MONTO_ORIGINAL, MONTO_PAGADO,
                           MONTO_MORA, MONTO_PENDIENTE, DIAS_ATRASO, ESTADO)
                          VALUES
                          (:IdResidente, :IdFactura, :MontoOriginal, :MontoPagado,
                           :MontoMora, :MontoPendiente, :DiasAtraso, :Estado)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(CuentaPorCobrarModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE CUENTA_POR_COBRAR SET
                          ID_RESIDENTE         = :IdResidente,
                          ID_FACTURA           = :IdFactura,
                          MONTO_ORIGINAL       = :MontoOriginal,
                          MONTO_PAGADO         = :MontoPagado,
                          MONTO_MORA           = :MontoMora,
                          MONTO_PENDIENTE      = :MontoPendiente,
                          DIAS_ATRASO          = :DiasAtraso,
                          ESTADO               = :Estado,
                          ULTIMA_ACTUALIZACION = CURRENT_TIMESTAMP
                          WHERE ID_CUENTA = :IdCuenta";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM CUENTA_POR_COBRAR WHERE ID_CUENTA = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}
