using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public PaisRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }


        public async Task<List<PaisModel>> GetAll()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM Pais";

                    Console.WriteLine(query);

                    var result = (await db.QueryAsync<PaisModel>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<PaisModel>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaisRequest> Create(PaisRequest request)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO PAIS(CODIGO, NOMBRE) VALUES('{request.Codigo}','{request.Nombre}')";

                    var result = await db.ExecuteAsync(query);

                    return request;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*public async Task<PaisModel> GetById(int id)
        {
            var pais = paises.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(pais);
        }*/

        public async Task<PaisModel> Update(PaisModel request, int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE PAIS SET CODIGO = '{request.codigo}', NOMBRE = '{request.nombre}' WHERE ID = {id}";

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
                    var query = $"DELETE FROM PAIS WHERE id = {id}";

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
