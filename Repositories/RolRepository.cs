using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace Condominio.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly IDbConnection _db;

        public RolRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<RolModel>> GetAllAsync()
        {
            const string sql = @"
                SELECT ID_ROL         AS IdRol,
                       NOMBRE         AS Nombre,
                       DESCRIPCION    AS Descripcion,
                       ACTIVO         AS Activo,
                       FECHA_REGISTRO AS FechaRegistro
                FROM ROL_SISTEMA
                ORDER BY NOMBRE";
            return await _db.QueryAsync<RolModel>(sql);
        }

        public async Task<RolModel?> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT ID_ROL         AS IdRol,
                       NOMBRE         AS Nombre,
                       DESCRIPCION    AS Descripcion,
                       ACTIVO         AS Activo,
                       FECHA_REGISTRO AS FechaRegistro
                FROM ROL_SISTEMA
                WHERE ID_ROL = :id";
            return await _db.QueryFirstOrDefaultAsync<RolModel>(sql, new { id });
        }

        public async Task<int> CreateAsync(RolCreateRequest request)
        {
            const string sql = @"
                INSERT INTO ROL_SISTEMA (NOMBRE, DESCRIPCION, ACTIVO, FECHA_REGISTRO)
                VALUES (:Nombre, :Descripcion, 1, CURRENT_TIMESTAMP)";
            return await _db.ExecuteAsync(sql, request);
        }

        public async Task<int> UpdateAsync(int id, RolCreateRequest request)
        {
            const string sql = @"
                UPDATE ROL_SISTEMA
                SET NOMBRE      = :Nombre,
                    DESCRIPCION = :Descripcion
                WHERE ID_ROL = :id";
            return await _db.ExecuteAsync(sql, new { request.Nombre, request.Descripcion, id });
        }

        public async Task<int> ToggleActivoAsync(int id, int activo)
        {
            const string sql = "UPDATE ROL_SISTEMA SET ACTIVO = :activo WHERE ID_ROL = :id";
            return await _db.ExecuteAsync(sql, new { activo, id });
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM ROL_SISTEMA WHERE ID_ROL = :id";
            return await _db.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<PermisoModel>> GetPermisosAsync(int idRol)
        {
            const string sql = @"
                SELECT p.ID_PERMISO  AS IdPermiso,
                       p.MODULO      AS Modulo,
                       p.ACCION      AS Accion,
                       p.DESCRIPCION AS Descripcion
                FROM PERMISO p
                JOIN ROL_PERMISO rp ON rp.ID_PERMISO = p.ID_PERMISO
                WHERE rp.ID_ROL = :idRol
                ORDER BY p.MODULO, p.ACCION";
            return await _db.QueryAsync<PermisoModel>(sql, new { idRol });
        }

        public async Task<int> AsignarPermisoAsync(int idRol, int idPermiso)
        {
            const string sql = @"
                INSERT INTO ROL_PERMISO (ID_ROL, ID_PERMISO)
                VALUES (:idRol, :idPermiso)";
            return await _db.ExecuteAsync(sql, new { idRol, idPermiso });
        }

        public async Task<int> QuitarPermisoAsync(int idRol, int idPermiso)
        {
            const string sql = @"
                DELETE FROM ROL_PERMISO
                WHERE ID_ROL = :idRol AND ID_PERMISO = :idPermiso";
            return await _db.ExecuteAsync(sql, new { idRol, idPermiso });
        }
    }
}