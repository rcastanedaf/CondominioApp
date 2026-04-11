using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class tipoPropiedadRepository : ItipoPropiedadRepository
    {
        private readonly string _stringConnection;

        public tipoPropiedadRepository(IConfiguration configuration)
        {
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<tipoPropiedadModel>> GetAll()
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "SELECT * FROM tipo_propiedad";
                return (await db.QueryAsync<tipoPropiedadModel>(query)).ToList();
            }
        }

        public async Task<tipoPropiedadRequest> Create(tipoPropiedadRequest request)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = @"
                INSERT INTO tipo_propiedad (nombre, descripcion)
                VALUES (:nombre, :descripcion)";

                await db.ExecuteAsync(query, request, commandTimeout: 30);
                return request;
            }
        }

        public async Task<tipoPropiedadModel> Update(tipoPropiedadModel request, int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = @"
                UPDATE tipo_propiedad SET
                    nombre      = :nombre,
                    descripcion = :descripcion
                WHERE id_tipo_propiedad = :id";

                await db.ExecuteAsync(query, new
                {
                    id,
                    request.nombre,
                    request.descripcion
                }, commandTimeout: 30);

                return request;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = "DELETE FROM tipo_propiedad WHERE id_tipo_propiedad = :id";
                await db.ExecuteAsync(query, new { id }, commandTimeout: 30);
                return true;
            }
        }
    }
}