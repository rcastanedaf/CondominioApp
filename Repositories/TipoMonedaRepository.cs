using System.Data;
using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class TipoMonedaRepository : ITipoMonedaRepository
    {

        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public TipoMonedaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<TipoMonedaModel>> GetAllAsync()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM TipoMoneda";

                    var result = (await db.QueryAsync<TipoMonedaModel>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<TipoMonedaModel>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TipoMonedaCreateRequest> CreateAsync(TipoMonedaCreateRequest request)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO TipoMoneda(codigo, nombre, simbolo, tipo_cambio_gtq) " +
                        $"VALUES ('{request.codigo}', '{request.nombre}', '{request.simbolo}', {request.tipo_cambio_gtq})";

                    var result = await db.ExecuteAsync(query);

                    return request;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TipoMonedaModel> UpdateAsync(TipoMonedaModel request, int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE TipoCambio SET codigo = '{request.codigo}', nombre = '{request.nombre}', " +
                        $"simbolo = '{request.simbolo}', tipo_cambio_gtq = {request.tipo_cambio_gtq} WHERE id = {id}";

                    var result = await db.ExecuteAsync(query);

                    return request;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"DELETE FROM TipoMoneda WHERE id = {id}";

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
