using System.Data;
using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class MetodoPagoRepository : IMetodoPagoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public MetodoPagoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = _configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<MetodoPagoCreateRequest> CreateAsync(MetodoPagoCreateRequest request)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO MetodoPago(nombre) " +
                        $"VALUES ('{request.Nombre}')";

                    var result = await db.ExecuteAsync(query);

                    return request;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear tipo de moneda", ex);
            }
        }

        public async Task<List<MetodoPagoModel>> GetAllAsync()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM MetodoPago";

                    var result = (await db.QueryAsync<MetodoPagoModel>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<MetodoPagoModel>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener tipos de moneda", ex);
            }
        }

        public async Task<MetodoPagoModel> UpdateAsync(MetodoPagoModel request, int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE MetodoPago SET nombre = '{request.Nombre}', activo = {request.Activo} WHERE id = {id}";

                    var result = await db.ExecuteAsync(query);

                    return request;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener tipos de moneda", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"DELETE FROM MetodoPago WHERE id = {id}";

                    var result = await db.ExecuteAsync(query);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener tipos de moneda", ex);
            }
        }
    }
}
