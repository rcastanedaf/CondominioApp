using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class CategoriaIncidenciaRepository : ICategoriaIncidenciaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public CategoriaIncidenciaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<CategoriaIncidenciaModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                            ID_CATEGORIA IdCategoria,
                            NOMBRE Nombre,
                            PRIORIDAD_DEFAULT PrioridadDefault
                          FROM CATEGORIA_INCIDENCIA";

            return (await db.QueryAsync<CategoriaIncidenciaModel>(query)).ToList();
        }

        public async Task<CategoriaIncidenciaModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                            ID_CATEGORIA IdCategoria,
                            NOMBRE Nombre,
                            PRIORIDAD_DEFAULT PrioridadDefault
                          FROM CATEGORIA_INCIDENCIA
                          WHERE ID_CATEGORIA = :id";

            return await db.QueryFirstOrDefaultAsync<CategoriaIncidenciaModel>(query, new { id });
        }

        public async Task CreateAsync(CategoriaIncidenciaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO CATEGORIA_INCIDENCIA
                          (NOMBRE, PRIORIDAD_DEFAULT)
                          VALUES (:Nombre, :PrioridadDefault)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(CategoriaIncidenciaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE CATEGORIA_INCIDENCIA
                          SET NOMBRE = :Nombre,
                              PRIORIDAD_DEFAULT = :PrioridadDefault
                          WHERE ID_CATEGORIA = :IdCategoria";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"DELETE FROM CATEGORIA_INCIDENCIA
                          WHERE ID_CATEGORIA = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}