using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class contratoRepository : IcontratoRepository
    {
        private readonly string _stringConnection;

        public contratoRepository(IConfiguration configuration)
        {
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<contratoModel>> GetAll()
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "SELECT * FROM contrato";
                return (await db.QueryAsync<contratoModel>(query)).ToList();
            }
        }

        public async Task<contratoRequest> Create(contratoRequest request)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = @"
                INSERT INTO contrato
                    (id_propiedad, id_residente, id_tipo_contrato, tipo_contrato,
                     fecha_inicio, fecha_fin, monto, id_moneda, deposito_garantia, estado)
                VALUES
                    (:id_propiedad, :id_residente, :id_tipo_contrato, :tipo_contrato,
                     :fecha_inicio, :fecha_fin, :monto, :id_moneda, :deposito_garantia, :estado)";

                await db.ExecuteAsync(query, new
                {
                    request.id_propiedad,
                    request.id_residente,
                    id_tipo_contrato = request.id_tipo_contrato == 0 ? (int?)null : request.id_tipo_contrato,
                    request.tipo_contrato,
                    request.fecha_inicio,
                    request.fecha_fin,
                    request.monto,
                    id_moneda = request.id_moneda == 0 ? (int?)null : request.id_moneda,
                    request.deposito_garantia,
                    request.estado
                }, commandTimeout: 30);

                return request;
            }
        }

        public async Task<contratoModel> Update(contratoModel request, int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                db.Open();
                var query = @"
                UPDATE contrato SET
                    id_propiedad      = :id_propiedad,
                    id_residente      = :id_residente,
                    id_tipo_contrato  = :id_tipo_contrato,
                    tipo_contrato     = :tipo_contrato,
                    fecha_inicio      = :fecha_inicio,
                    fecha_fin         = :fecha_fin,
                    monto             = :monto,
                    id_moneda         = :id_moneda,
                    deposito_garantia = :deposito_garantia,
                    estado            = :estado
                WHERE id_contrato = :id";

                await db.ExecuteAsync(query, new
                {
                    id,
                    request.id_propiedad,
                    request.id_residente,
                    request.id_tipo_contrato,
                    request.tipo_contrato,
                    request.fecha_inicio,
                    request.fecha_fin,
                    request.monto,
                    request.id_moneda,
                    request.deposito_garantia,
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
                var query = "DELETE FROM contrato WHERE id_contrato = :id";
                await db.ExecuteAsync(query, new { id }, commandTimeout: 30);
                return true;
            }
        }
    }
}