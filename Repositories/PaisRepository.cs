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
        private readonly string _conn;

        public PaisRepository(IConfiguration configuration)
        {
            _conn = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<PaisModel>> GetAll()
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = @"
                SELECT ID     AS id,
                       CODIGO AS codigo,
                       NOMBRE AS nombre
                FROM PAIS
                ORDER BY NOMBRE";
            return (await db.QueryAsync<PaisModel>(sql)).ToList();
        }

        public async Task<PaisModel?> GetById(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = @"
                SELECT ID     AS id,
                       CODIGO AS codigo,
                       NOMBRE AS nombre
                FROM PAIS
                WHERE ID = :id";
            return await db.QueryFirstOrDefaultAsync<PaisModel>(sql, new { id });
        }

        public async Task<int> Create(PaisRequest request)
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = @"
                INSERT INTO PAIS (CODIGO, NOMBRE)
                VALUES (:Codigo, :Nombre)";
            return await db.ExecuteAsync(sql, request);
        }

        public async Task<int> Update(int id, PaisRequest request)
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = @"
                UPDATE PAIS
                SET CODIGO = :Codigo,
                    NOMBRE = :Nombre
                WHERE ID = :id";
            return await db.ExecuteAsync(sql, new { request.Codigo, request.Nombre, id });
        }

        public async Task<bool> Delete(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = "DELETE FROM PAIS WHERE ID = :id";
            var rows = await db.ExecuteAsync(sql, new { id });
            return rows > 0;
        }
    }
}