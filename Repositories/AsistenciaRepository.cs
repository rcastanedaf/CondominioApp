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
        public async Task<List<AsistenciaModel>> GetByEmpleado(int id) { 
            using IDbConnection db = new OracleConnection(_conn);
            return (await db.QueryAsync<AsistenciaModel>("SELECT ID_ASISTENCIA Id_Asistencia,ID_EMPLEADO Id_Empleado,TO_CHAR(FECHA,'YYYY-MM-DD') Fecha,TO_CHAR(HORA_ENTRADA,'YYYY-MM-DD HH24:MI') Hora_Entrada,TO_CHAR(HORA_SALIDA,'YYYY-MM-DD HH24:MI') Hora_Salida,ESTADO,MINUTOS_EXTRA Minutos_Extra,MINUTOS_TARDANZA Minutos_Tardanza,OBSERVACIONES FROM ASISTENCIA WHERE ID_EMPLEADO=:id ORDER BY FECHA DESC", new { id })).ToList(); 
        }
        public async Task<AsistenciaCreateRequest> Create(AsistenciaCreateRequest r) { 
            using IDbConnection db = new OracleConnection(_conn); await db.ExecuteAsync("INSERT INTO ASISTENCIA(ID_EMPLEADO,FECHA,HORA_ENTRADA,ESTADO,MINUTOS_EXTRA,MINUTOS_TARDANZA,OBSERVACIONES,REGISTRADO_POR) VALUES(:Id_Empleado,TO_DATE(:Fecha,'YYYY-MM-DD'),SYSTIMESTAMP,:Estado,:Minutos_Extra,:Minutos_Tardanza,:Observaciones,:Registrado_Por)", r); return r; 
        }
        public async Task<bool> RegistrarSalida(int id) { 
            using IDbConnection db = new OracleConnection(_conn); await db.ExecuteAsync("UPDATE ASISTENCIA SET HORA_SALIDA=SYSTIMESTAMP WHERE ID_ASISTENCIA=:id", new { id }); return true; 
        }

    }
}
