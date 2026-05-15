using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace Condominio.Repositories
{
    public class FamiliarResidenteRepository : IFamiliarResidenteRepository
    {
        private readonly IDbConnection _db;

        public FamiliarResidenteRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<FamiliarResidenteModel>> GetAllAsync()
        {
            const string sql = @"
                SELECT f.ID_FAMILIAR       AS IdFamiliar,
                       f.ID_RESIDENTE      AS IdResidente,
                       f.ID_PERSONA        AS IdPersona,
                       f.ID_PARENTESCO     AS IdParentesco,
                       f.OBSERVACIONES     AS Observaciones,
                       f.ACTIVO            AS Activo,
                       p.NOMBRES || ' ' || p.APELLIDOS AS NombrePersona,
                       pa.NOMBRE           AS NombreParentesco
                FROM FAMILIAR_RESIDENTE f
                JOIN PERSONA p   ON p.ID_PERSONA  = f.ID_PERSONA
                LEFT JOIN PARENTESCO pa ON pa.ID = f.ID_PARENTESCO
                ORDER BY f.ID_FAMILIAR";
            return await _db.QueryAsync<FamiliarResidenteModel>(sql);
        }

        public async Task<IEnumerable<FamiliarResidenteModel>> GetByResidenteAsync(int idResidente)
        {
            const string sql = @"
                SELECT f.ID_FAMILIAR       AS IdFamiliar,
                       f.ID_RESIDENTE      AS IdResidente,
                       f.ID_PERSONA        AS IdPersona,
                       f.ID_PARENTESCO     AS IdParentesco,
                       f.OBSERVACIONES     AS Observaciones,
                       f.ACTIVO            AS Activo,
                       p.NOMBRES || ' ' || p.APELLIDOS AS NombrePersona,
                       pa.NOMBRE           AS NombreParentesco
                FROM FAMILIAR_RESIDENTE f
                JOIN PERSONA p   ON p.ID_PERSONA  = f.ID_PERSONA
                LEFT JOIN PARENTESCO pa ON pa.ID = f.ID_PARENTESCO
                WHERE f.ID_RESIDENTE = :idResidente
                ORDER BY f.ID_FAMILIAR";
            return await _db.QueryAsync<FamiliarResidenteModel>(sql, new { idResidente });
        }

        public async Task<FamiliarResidenteModel?> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT f.ID_FAMILIAR       AS IdFamiliar,
                       f.ID_RESIDENTE      AS IdResidente,
                       f.ID_PERSONA        AS IdPersona,
                       f.ID_PARENTESCO     AS IdParentesco,
                       f.OBSERVACIONES     AS Observaciones,
                       f.ACTIVO            AS Activo,
                       p.NOMBRES || ' ' || p.APELLIDOS AS NombrePersona,
                       pa.NOMBRE           AS NombreParentesco
                FROM FAMILIAR_RESIDENTE f
                JOIN PERSONA p   ON p.ID_PERSONA  = f.ID_PERSONA
                LEFT JOIN PARENTESCO pa ON pa.ID = f.ID_PARENTESCO
                WHERE f.ID_FAMILIAR = :id";
            return await _db.QueryFirstOrDefaultAsync<FamiliarResidenteModel>(sql, new { id });
        }

        public async Task<int> CreateAsync(FamiliarResidenteCreateRequest request)
        {
            const string sql = @"
                INSERT INTO FAMILIAR_RESIDENTE (ID_RESIDENTE, ID_PERSONA, ID_PARENTESCO, OBSERVACIONES, ACTIVO)
                VALUES (:IdResidente, :IdPersona, :IdParentesco, :Observaciones, 1)";
            return await _db.ExecuteAsync(sql, request);
        }

        public async Task<int> UpdateAsync(int id, FamiliarResidenteUpdateRequest request)
        {
            const string sql = @"
                UPDATE FAMILIAR_RESIDENTE
                SET ID_PARENTESCO = :IdParentesco,
                    OBSERVACIONES = :Observaciones,
                    ACTIVO        = :Activo
                WHERE ID_FAMILIAR = :id";
            return await _db.ExecuteAsync(sql, new
            {
                request.IdParentesco,
                request.Observaciones,
                request.Activo,
                id
            });
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM FAMILIAR_RESIDENTE WHERE ID_FAMILIAR = :id";
            return await _db.ExecuteAsync(sql, new { id });
        }

        public async Task<int> ToggleActivoAsync(int id, int activo)
        {
            const string sql = "UPDATE FAMILIAR_RESIDENTE SET ACTIVO = :activo WHERE ID_FAMILIAR = :id";
            return await _db.ExecuteAsync(sql, new { activo, id });
        }
    }
}