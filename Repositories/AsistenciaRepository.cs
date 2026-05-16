using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly string _conn;
        public AsistenciaRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;
        public async Task<List<AsistenciaModel>> GetByEmpleado(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            return (await db.QueryAsync<AsistenciaModel>(@"
                SELECT ID_ASISTENCIA      AS Id_Asistencia,
                       ID_EMPLEADO        AS Id_Empleado,
                       TO_CHAR(FECHA,'YYYY-MM-DD') AS Fecha,
                       TO_CHAR(HORA_ENTRADA,'YYYY-MM-DD HH24:MI') AS Hora_Entrada,
                       TO_CHAR(HORA_SALIDA,'YYYY-MM-DD HH24:MI')  AS Hora_Salida,
                       ESTADO,
                       MINUTOS_EXTRA      AS Minutos_Extra,
                       MINUTOS_TARDANZA   AS Minutos_Tardanza
                FROM ASISTENCIA
                WHERE ID_EMPLEADO = :id
                ORDER BY FECHA DESC",
                new { id })).ToList();
        }
        public async Task<AsistenciaCreateRequest> Create(AsistenciaCreateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync(@"
        INSERT INTO ASISTENCIA
            (ID_EMPLEADO, FECHA, HORA_ENTRADA, ESTADO,
             MINUTOS_EXTRA, MINUTOS_TARDANZA, REGISTRADO_POR)
        VALUES
            (:Id_Empleado, TRUNC(SYSDATE), SYSTIMESTAMP, :Estado,
             :Minutos_Extra, :Minutos_Tardanza, :Registrado_Por)",
                r);
            return r;
        }
        public async Task<bool> RegistrarSalida(int id) { 
            using IDbConnection db = new OracleConnection(_conn); await db.ExecuteAsync("UPDATE ASISTENCIA SET HORA_SALIDA=SYSTIMESTAMP WHERE ID_ASISTENCIA=:id", new { id }); return true; 
        }

    }
}
