using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public BancoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<List<Banco>> GetAllAsync()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM Banco";

                    var result = (await db.QueryAsync<Banco>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Banco>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Banco>> GetId(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Banco WHERE id = {id}";

                    var result = (await db.QueryAsync<Banco>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Banco>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Banco>> GetNombre(string nombre)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Banco WHERE nombre = {nombre}";

                    var result = (await db.QueryAsync<Banco>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Banco>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BancoCreateRequest> CreateBanco(BancoCreateRequest newBanco)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO Banco(nombre, activo) " +
                        $"VALUES ('{newBanco.Nombre}', '{newBanco.Activo}')";

                    var result = await db.ExecuteAsync(query);

                    return newBanco;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BancoUpdateRequest> UpdateBanco(BancoUpdateRequest editBanco)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE Banco SET nombre = '{editBanco.Nombre}', activo = '{editBanco.Activo}' WHERE id = {editBanco.Id}";

                    var result = await db.ExecuteAsync(query);

                    return editBanco;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteBanco(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"DELETE FROM Banco WHERE id = {id}";

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
