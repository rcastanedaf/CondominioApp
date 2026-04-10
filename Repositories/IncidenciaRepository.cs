using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class IncidenciaRepository : IIncidenciaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public IncidenciaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<IncidenciaModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                            ID_INCIDENCIA IdIncidencia,
                            ID_PROPIEDAD IdPropiedad,
                            ID_ESPACIO IdEspacio,
                            ID_CATEGORIA IdCategoria,
                            TITULO Titulo,
                            PRIORIDAD Prioridad,
                            ESTADO Estado
                          FROM INCIDENCIA";

            return (await db.QueryAsync<IncidenciaModel>(query)).ToList();
        }

        public async Task<IncidenciaModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                            ID_INCIDENCIA IdIncidencia,
                            ID_PROPIEDAD IdPropiedad,
                            ID_ESPACIO IdEspacio,
                            ID_CATEGORIA IdCategoria,
                            TITULO Titulo,
                            PRIORIDAD Prioridad,
                            ESTADO Estado
                          FROM INCIDENCIA
                          WHERE ID_INCIDENCIA = :id";

            return await db.QueryFirstOrDefaultAsync<IncidenciaModel>(query, new { id });
        }

        public async Task CreateAsync(IncidenciaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO INCIDENCIA
                          (ID_PROPIEDAD, ID_ESPACIO, ID_CATEGORIA, TITULO, PRIORIDAD, ESTADO)
                          VALUES
                          (:IdPropiedad, :IdEspacio, :IdCategoria, :Titulo, :Prioridad, :Estado)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(IncidenciaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE INCIDENCIA SET
                          ID_PROPIEDAD = :IdPropiedad,
                          ID_ESPACIO = :IdEspacio,
                          ID_CATEGORIA = :IdCategoria,
                          TITULO = :Titulo,
                          PRIORIDAD = :Prioridad,
                          ESTADO = :Estado
                          WHERE ID_INCIDENCIA = :IdIncidencia";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM INCIDENCIA WHERE ID_INCIDENCIA = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}