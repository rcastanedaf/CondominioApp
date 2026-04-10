using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class MotivoVisitaRepository : IMotivoVisitaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public MotivoVisitaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<MotivoVisitaModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_connectionString);

            var query = @"SELECT 
                            ID Id,
                            DESCRIPCION Descripcion
                          FROM MOTIVO_VISITA";

            return (await db.QueryAsync<MotivoVisitaModel>(query)).ToList();
        }

        public async Task<MotivoVisitaModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_connectionString);

            var query = @"SELECT 
                            ID Id,
                            DESCRIPCION Descripcion
                          FROM MOTIVO_VISITA
                          WHERE ID = :id";

            return await db.QueryFirstOrDefaultAsync<MotivoVisitaModel>(query, new { id });
        }

        public async Task<MotivoVisitaModel> CreateAsync(MotivoVisitaModel model)
        {
            using IDbConnection db = new OracleConnection(_connectionString);

            var query = @"INSERT INTO MOTIVO_VISITA (DESCRIPCION)
                          VALUES (:Descripcion)";

            await db.ExecuteAsync(query, model);

            return model;
        }

        public async Task<bool> UpdateAsync(MotivoVisitaModel model)
        {
            using IDbConnection db = new OracleConnection(_connectionString);

            var query = @"UPDATE MOTIVO_VISITA
                          SET DESCRIPCION = :Descripcion
                          WHERE ID = :Id";

            var result = await db.ExecuteAsync(query, model);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_connectionString);

            var query = "DELETE FROM MOTIVO_VISITA WHERE ID = :id";

            var result = await db.ExecuteAsync(query, new { id });

            return result > 0;
        }
    }
}