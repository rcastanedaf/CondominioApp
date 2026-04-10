using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class SeguimientoIncidenciaRepository : ISeguimientoIncidenciaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public SeguimientoIncidenciaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<SeguimientoIncidenciaModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                            ID_SEGUIMIENTO IdSeguimiento,
                            ID_INCIDENCIA IdIncidencia,
                            COMENTARIO Comentario,
                            ESTADO_NUEVO EstadoNuevo,
                            FECHA Fecha
                          FROM SEGUIMIENTO_INCIDENCIA";

            return (await db.QueryAsync<SeguimientoIncidenciaModel>(query)).ToList();
        }

        public async Task<SeguimientoIncidenciaModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                            ID_SEGUIMIENTO IdSeguimiento,
                            ID_INCIDENCIA IdIncidencia,
                            COMENTARIO Comentario,
                            ESTADO_NUEVO EstadoNuevo,
                            FECHA Fecha
                          FROM SEGUIMIENTO_INCIDENCIA
                          WHERE ID_SEGUIMIENTO = :id";

            return await db.QueryFirstOrDefaultAsync<SeguimientoIncidenciaModel>(query, new { id });
        }

        public async Task CreateAsync(SeguimientoIncidenciaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO SEGUIMIENTO_INCIDENCIA
                          (ID_INCIDENCIA, COMENTARIO, ESTADO_NUEVO, FECHA)
                          VALUES
                          (:IdIncidencia, :Comentario, :EstadoNuevo, :Fecha)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(SeguimientoIncidenciaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE SEGUIMIENTO_INCIDENCIA SET
                          ID_INCIDENCIA = :IdIncidencia,
                          COMENTARIO = :Comentario,
                          ESTADO_NUEVO = :EstadoNuevo,
                          FECHA = :Fecha
                          WHERE ID_SEGUIMIENTO = :IdSeguimiento";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM SEGUIMIENTO_INCIDENCIA WHERE ID_SEGUIMIENTO = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}