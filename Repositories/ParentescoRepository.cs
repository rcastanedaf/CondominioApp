using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Data;

namespace Condominio.Repositories
{
    public class ParentescoRepository : IParentescoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;
        public ParentescoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<ParentescoModel>> GetAll()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM Parentesco";

                    Console.WriteLine(query);

                    var result = (await db.QueryAsync<ParentescoModel>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<ParentescoModel>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ParentescoRequest> Create(ParentescoRequest request)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO Parentesco(nombre) values('{request.Nombre}')";

                    var result = await db.ExecuteAsync(query);

                    return request;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ParentescoModel> Update(ParentescoModel request, int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE Parentesco SET nombre = '{request.Nombre}' WHERE id = {id}";

                    var result = await db.ExecuteAsync(query);

                    return request;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"DELETE FROM Parentesco WHERE id = {id}";

                    var result = await db.ExecuteAsync(query);

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
