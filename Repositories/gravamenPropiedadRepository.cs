using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class gravamenPropiedadRepository : IgravamenPropiedadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public gravamenPropiedadRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<gravamenPropiedadModel>> GetAll()
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "SELECT * FROM gravamen_propiedad";
                var result = (await db.QueryAsync<gravamenPropiedadModel>(query)).ToList();
                return result;
            }
        }

        public async Task<gravamenPropiedadRequest> Create(gravamenPropiedadRequest request)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                // Abre la conexión explícitamente para detectar si falla ahí
                db.Open();

                var query = @"
        INSERT INTO gravamen_propiedad
        (id_propiedad, id_banco, tipo, numero_escritura, monto_original,
         id_moneda, fecha_constitucion, fecha_cancelacion, notario,
         registro_url, activo, observaciones)
        VALUES
        (:id_propiedad, :id_banco, :tipo, :numero_escritura, :monto_original,
         :id_moneda, :fecha_constitucion, :fecha_cancelacion, :notario,
         :registro_url, :activo, :observaciones)";

                await db.ExecuteAsync(query, new
                {
                    request.id_propiedad,
                    request.id_banco,
                    tipo = request.tipo ?? "HIPOTECA",
                    request.numero_escritura,
                    request.monto_original,
                    id_moneda = (request.id_moneda == 0) ? (int?)null : request.id_moneda,
                    request.fecha_constitucion,
                    request.fecha_cancelacion,
                    request.notario,
                    request.registro_url,
                    request.activo,
                    request.observaciones
                }, commandTimeout: 30); // ← timeout de 30 segundos

                return request;
            }
        }

        public async Task<gravamenPropiedadModel> Update(gravamenPropiedadModel request, int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = @"
                UPDATE gravamen_propiedad SET
                    id_propiedad = :id_propiedad,
                    id_banco = :id_banco,
                    tipo = :tipo,
                    numero_escritura = :numero_escritura,
                    monto_original = :monto_original,
                    id_moneda = :id_moneda,
                    fecha_constitucion = :fecha_constitucion,
                    fecha_cancelacion = :fecha_cancelacion,
                    notario = :notario,
                    registro_url = :registro_url,
                    activo = :activo,
                    observaciones = :observaciones
                WHERE id_gravamen = :id";

                await db.ExecuteAsync(query, new
                {
                    request.id_propiedad,
                    request.id_banco,
                    request.tipo,
                    request.numero_escritura,
                    request.monto_original,
                    request.id_moneda,
                    request.fecha_constitucion,
                    request.fecha_cancelacion,
                    request.notario,
                    request.registro_url,
                    request.activo,
                    request.observaciones,
                    id,
                });

                return request;
            }   
        }

        public async Task<bool> Delete(int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "DELETE FROM gravamen_propiedad WHERE id_gravamen = :id";
                await db.ExecuteAsync(query, new { id });
                return true;
            }
        }
    }
}