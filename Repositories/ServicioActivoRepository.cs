using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace Condominio.Repositories
{
    public class ServicioActivoRepository : IServicioActivoRepository
    {
        private readonly IDbConnection _db;

        public ServicioActivoRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ServicioActivoModel>> GetAllAsync()
        {
            const string sql = @"
                SELECT sa.ID_SERVICIO_ACTIVO AS IdServicioActivo,
                       sa.ID_PROPIEDAD       AS IdPropiedad,
                       sa.ID_TIPO_SERVICIO   AS IdTipoServicio,
                       sa.FECHA_INICIO       AS FechaInicio,
                       sa.FECHA_FIN          AS FechaFin,
                       sa.ACTIVO             AS Activo,
                       ts.NOMBRE             AS NombreTipoServicio
                FROM SERVICIO_ACTIVO sa
                JOIN TIPO_SERVICIO ts ON ts.ID_TIPO_SERVICIO = sa.ID_TIPO_SERVICIO
                ORDER BY sa.ID_SERVICIO_ACTIVO";
            return await _db.QueryAsync<ServicioActivoModel>(sql);
        }

        public async Task<IEnumerable<ServicioActivoModel>> GetByPropiedadAsync(int idPropiedad)
        {
            const string sql = @"
                SELECT sa.ID_SERVICIO_ACTIVO AS IdServicioActivo,
                       sa.ID_PROPIEDAD       AS IdPropiedad,
                       sa.ID_TIPO_SERVICIO   AS IdTipoServicio,
                       sa.FECHA_INICIO       AS FechaInicio,
                       sa.FECHA_FIN          AS FechaFin,
                       sa.ACTIVO             AS Activo,
                       ts.NOMBRE             AS NombreTipoServicio
                FROM SERVICIO_ACTIVO sa
                JOIN TIPO_SERVICIO ts ON ts.ID_TIPO_SERVICIO = sa.ID_TIPO_SERVICIO
                WHERE sa.ID_PROPIEDAD = :idPropiedad
                ORDER BY sa.ID_SERVICIO_ACTIVO";
            return await _db.QueryAsync<ServicioActivoModel>(sql, new { idPropiedad });
        }

        public async Task<ServicioActivoModel?> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT sa.ID_SERVICIO_ACTIVO AS IdServicioActivo,
                       sa.ID_PROPIEDAD       AS IdPropiedad,
                       sa.ID_TIPO_SERVICIO   AS IdTipoServicio,
                       sa.FECHA_INICIO       AS FechaInicio,
                       sa.FECHA_FIN          AS FechaFin,
                       sa.ACTIVO             AS Activo,
                       ts.NOMBRE             AS NombreTipoServicio
                FROM SERVICIO_ACTIVO sa
                JOIN TIPO_SERVICIO ts ON ts.ID_TIPO_SERVICIO = sa.ID_TIPO_SERVICIO
                WHERE sa.ID_SERVICIO_ACTIVO = :id";
            return await _db.QueryFirstOrDefaultAsync<ServicioActivoModel>(sql, new { id });
        }

        public async Task<int> CreateAsync(ServicioActivoCreateRequest request)
        {
            const string sql = @"
                INSERT INTO SERVICIO_ACTIVO (ID_PROPIEDAD, ID_TIPO_SERVICIO, FECHA_INICIO, FECHA_FIN, ACTIVO)
                VALUES (:IdPropiedad, :IdTipoServicio, :FechaInicio, :FechaFin, 1)";
            return await _db.ExecuteAsync(sql, request);
        }

        public async Task<int> UpdateAsync(int id, ServicioActivoUpdateRequest request)
        {
            const string sql = @"
                UPDATE SERVICIO_ACTIVO
                SET FECHA_FIN = :FechaFin,
                    ACTIVO    = :Activo
                WHERE ID_SERVICIO_ACTIVO = :id";
            return await _db.ExecuteAsync(sql, new { request.Fecha_Fin, request.Activo, id });
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM SERVICIO_ACTIVO WHERE ID_SERVICIO_ACTIVO = :id";
            return await _db.ExecuteAsync(sql, new { id });
        }
    }
}