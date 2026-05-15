using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace Condominio.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly IDbConnection _db;

        public RegionRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<RegionModel>> GetAllAsync()
        {
            const string sql = @"
                SELECT r.ID_REGION AS IdRegion,
                       r.NOMBRE    AS Nombre,
                       r.ID_PAIS   AS IdPais,
                       p.NOMBRE    AS NombrePais
                FROM REGION r
                LEFT JOIN PAIS p ON p.ID = r.ID_PAIS
                ORDER BY r.NOMBRE";
            return await _db.QueryAsync<RegionModel>(sql);
        }

        public async Task<IEnumerable<RegionModel>> GetByPaisAsync(int idPais)
        {
            const string sql = @"
                SELECT r.ID_REGION AS IdRegion,
                       r.NOMBRE    AS Nombre,
                       r.ID_PAIS   AS IdPais,
                       p.NOMBRE    AS NombrePais
                FROM REGION r
                LEFT JOIN PAIS p ON p.ID = r.ID_PAIS
                WHERE r.ID_PAIS = :idPais
                ORDER BY r.NOMBRE";
            return await _db.QueryAsync<RegionModel>(sql, new { idPais });
        }

        public async Task<RegionModel?> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT r.ID_REGION AS IdRegion,
                       r.NOMBRE    AS Nombre,
                       r.ID_PAIS   AS IdPais,
                       p.NOMBRE    AS NombrePais
                FROM REGION r
                LEFT JOIN PAIS p ON p.ID = r.ID_PAIS
                WHERE r.ID_REGION = :id";
            return await _db.QueryFirstOrDefaultAsync<RegionModel>(sql, new { id });
        }

        public async Task<int> CreateAsync(RegionModel model)
        {
            const string sql = @"
                INSERT INTO REGION (NOMBRE, ID_PAIS)
                VALUES (:Nombre, :IdPais)";
            return await _db.ExecuteAsync(sql, model);
        }

        public async Task<int> UpdateAsync(RegionModel model)
        {
            const string sql = @"
                UPDATE REGION
                SET NOMBRE  = :Nombre,
                    ID_PAIS = :IdPais
                WHERE ID_REGION = :IdRegion";
            return await _db.ExecuteAsync(sql, model);
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM REGION WHERE ID_REGION = :id";
            return await _db.ExecuteAsync(sql, new { id });
        }
    }
}