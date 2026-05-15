using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace Condominio.Repositories
{
    public class PermisoRepository : IPermisoRepository
    {
        private readonly IDbConnection _db;

        public PermisoRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PermisoModel>> GetAllAsync()
        {
            const string sql = @"
                SELECT ID_PERMISO  AS IdPermiso,
                       MODULO      AS Modulo,
                       ACCION      AS Accion,
                       DESCRIPCION AS Descripcion
                FROM PERMISO
                ORDER BY MODULO, ACCION";
            return await _db.QueryAsync<PermisoModel>(sql);
        }

        public async Task<PermisoModel?> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT ID_PERMISO  AS IdPermiso,
                       MODULO      AS Modulo,
                       ACCION      AS Accion,
                       DESCRIPCION AS Descripcion
                FROM PERMISO
                WHERE ID_PERMISO = :id";
            return await _db.QueryFirstOrDefaultAsync<PermisoModel>(sql, new { id });
        }
    }
}