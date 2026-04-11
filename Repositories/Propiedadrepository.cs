using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class propiedadRepository : IpropiedadRepository
    {
        private readonly string _stringConnection;

        public propiedadRepository(IConfiguration configuration)
        {
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<propiedadModel>> GetAll()
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "SELECT * FROM propiedad";
                return (await db.QueryAsync<propiedadModel>(query)).ToList();
            }
        }

        public async Task<propiedadRequest> Create(propiedadRequest request)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = @"
                INSERT INTO propiedad
                    (id_tipo_propiedad, codigo, nivel, area_m2,
                     num_habitaciones, num_parqueos, estado)
                VALUES
                    (:id_tipo_propiedad, :codigo, :nivel, :area_m2,
                     :num_habitaciones, :num_parqueos, :estado)";

                await db.ExecuteAsync(query, request, commandTimeout: 30);
                return request;
            }
        }

        public async Task<propiedadModel> Update(propiedadModel request, int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = @"
                UPDATE propiedad SET
                    id_tipo_propiedad = :id_tipo_propiedad,
                    codigo            = :codigo,
                    nivel             = :nivel,
                    area_m2           = :area_m2,
                    num_habitaciones  = :num_habitaciones,
                    num_parqueos      = :num_parqueos,
                    estado            = :estado
                WHERE id_propiedad = :id";

                await db.ExecuteAsync(query, new
                {
                    id,
                    request.id_tipo_propiedad,
                    request.codigo,
                    request.nivel,
                    request.area_m2,
                    request.num_habitaciones,
                    request.num_parqueos,
                    request.estado
                }, commandTimeout: 30);

                return request;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = "DELETE FROM propiedad WHERE id_propiedad = :id";
                await db.ExecuteAsync(query, new { id }, commandTimeout: 30);
                return true;
            }
        }
    }
}