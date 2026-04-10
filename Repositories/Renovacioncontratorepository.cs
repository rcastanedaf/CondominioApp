using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class renovacionContratoRepository : IrenovacionContratoRepository
    {
        private readonly string _stringConnection;

        public renovacionContratoRepository(IConfiguration configuration)
        {
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<renovacionContratoModel>> GetAll()
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "SELECT * FROM renovacion_contrato";
                return (await db.QueryAsync<renovacionContratoModel>(query)).ToList();
            }
        }

        public async Task<renovacionContratoRequest> Create(renovacionContratoRequest request)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = @"
                INSERT INTO renovacion_contrato
                    (id_contrato, fecha_nueva_vigencia, nuevo_monto, id_moneda)
                VALUES
                    (:id_contrato, :fecha_nueva_vigencia, :nuevo_monto, :id_moneda)";

                await db.ExecuteAsync(query, new
                {
                    request.id_contrato,
                    request.fecha_nueva_vigencia,
                    request.nuevo_monto,
                    id_moneda = request.id_moneda == 0 ? (int?)null : request.id_moneda
                }, commandTimeout: 30);

                return request;
            }
        }

        public async Task<renovacionContratoModel> Update(renovacionContratoModel request, int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = @"
                UPDATE renovacion_contrato SET
                    id_contrato           = :id_contrato,
                    fecha_nueva_vigencia  = :fecha_nueva_vigencia,
                    nuevo_monto           = :nuevo_monto,
                    id_moneda             = :id_moneda
                WHERE id_renovacion = :id";

                await db.ExecuteAsync(query, new
                {
                    id,
                    request.id_contrato,
                    request.fecha_nueva_vigencia,
                    request.nuevo_monto,
                    request.id_moneda
                }, commandTimeout: 30);

                return request;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = "DELETE FROM renovacion_contrato WHERE id_renovacion = :id";
                await db.ExecuteAsync(query, new { id }, commandTimeout: 30);
                return true;
            }
        }
    }
}