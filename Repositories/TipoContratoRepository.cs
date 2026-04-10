using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class TipoContratoRepository : ITipoContratoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public TipoContratoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<TipoContratoModel>> GetAllAsync()
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "SELECT * FROM TIPOCONTRATO";
                return (await db.QueryAsync<TipoContratoModel>(query)).ToList();
            }
        }

        public async Task<TipoContratoModel?> GetByIdAsync(int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "SELECT * FROM TIPOCONTRATO WHERE ID = :id";
                return await db.QueryFirstOrDefaultAsync<TipoContratoModel>(query, new { id });
            }
        }

        public async Task<TipoContratoModel> CreateAsync(TipoContratoModel model)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "INSERT INTO TIPOCONTRATO (nombre, activo) VALUES (:nombre, :activo)";

                await db.ExecuteAsync(query, new
                {
                    nombre = model.Nombre,
                    activo = 1
                });

                return model;
            }
        }

        public async Task<bool> UpdateAsync(TipoContratoModel model)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "UPDATE TIPOCONTRATO SET nombre = :nombre WHERE id = :id";

                var result = await db.ExecuteAsync(query, new
                {
                    nombre = model.Nombre,
                    id = model.Id
                });

                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "DELETE FROM TIPOCONTRATO WHERE id = :id";

                var result = await db.ExecuteAsync(query, new { id });

                return result > 0;
            }
        }
    }
}