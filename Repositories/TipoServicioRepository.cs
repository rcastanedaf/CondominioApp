using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class TipoServicioRepository : ITipoServicioRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public TipoServicioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<TipoServicioModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                            ID_TIPO_SERVICIO IdTipoServicio,
                            NOMBRE Nombre,
                            ID_UNIDAD_MEDIDA IdUnidad,
                            PERIODICIDAD Periodicidad,
                            MONTO_BASE MontoBase,
                            APLICA_IVA AplicaIva,
                            APLICA_MORA AplicaMora,
                            PORCENTAJE_MORA PorcentajeMora,
                            DIAS_GRACIA DiasGracia
                          FROM TIPO_SERVICIO";

            return (await db.QueryAsync<TipoServicioModel>(query)).ToList();
        }

        public async Task<TipoServicioModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                            ID_TIPO_SERVICIO IdTipoServicio,
                            NOMBRE Nombre,
                            ID_UNIDAD IdUnidad,
                            PERIODICIDAD Periodicidad,
                            MONTO_BASE MontoBase,
                            APLICA_IVA AplicaIva,
                            APLICA_MORA AplicaMora,
                            PORCENTAJE_MORA PorcentajeMora,
                            DIAS_GRACIA DiasGracia
                          FROM TIPO_SERVICIO
                          WHERE ID_TIPO_SERVICIO = :id";

            return await db.QueryFirstOrDefaultAsync<TipoServicioModel>(query, new { id });
        }

        public async Task CreateAsync(TipoServicioModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO TIPO_SERVICIO
                        (NOMBRE, ID_UNIDAD, PERIODICIDAD, MONTO_BASE, 
                         APLICA_IVA, APLICA_MORA, PORCENTAJE_MORA, DIAS_GRACIA)
                        VALUES
                        (:Nombre, :IdUnidad, :Periodicidad, :MontoBase,
                         :AplicaIva, :AplicaMora, :PorcentajeMora, :DiasGracia)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(TipoServicioModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE TIPO_SERVICIO SET
                        NOMBRE = :Nombre,
                        ID_UNIDAD_MEDIDA = :IdUnidad,
                        PERIODICIDAD = :Periodicidad,
                        MONTO_BASE = :MontoBase,
                        APLICA_IVA = :AplicaIva,
                        APLICA_MORA = :AplicaMora,
                        PORCENTAJE_MORA = :PorcentajeMora,
                        DIAS_GRACIA = :DiasGracia
                        WHERE ID_TIPO_SERVICIO = :IdTipoServicio";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM TIPO_SERVICIO WHERE ID_TIPO_SERVICIO = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}