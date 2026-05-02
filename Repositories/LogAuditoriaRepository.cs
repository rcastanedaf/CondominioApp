using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class LogAuditoriaRepository : ILogAuditoriaRepository
    {
        private readonly string _conn;
        public LogAuditoriaRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;

        public async Task<List<LogAuditoriaModel>> GetAllAsync(int top = 500)
        {
            using IDbConnection db = new OracleConnection(_conn);
            return (await db.QueryAsync<LogAuditoriaModel>($@"SELECT * FROM (
            SELECT ID_LOG Id_Log,ID_USUARIO Id_Usuario,USERNAME,MODULO,ACCION,
            TABLA_AFECTADA Tabla_Afectada,ID_REGISTRO Id_Registro,DESCRIPCION,
            IP_ORIGEN Ip_Origen,RESULTADO,TO_CHAR(FECHA_HORA,'YYYY-MM-DD HH24:MI:SS') Fecha_Hora
            FROM LOG_AUDITORIA ORDER BY FECHA_HORA DESC) WHERE ROWNUM<={top}")).ToList();
        }

        public async Task Registrar(LogAuditoriaCreateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync(@"INSERT INTO LOG_AUDITORIA(ID_USUARIO,USERNAME,MODULO,ACCION,TABLA_AFECTADA,
            ID_REGISTRO,DESCRIPCION,DATOS_ANTERIORES,DATOS_NUEVOS,IP_ORIGEN,RESULTADO,MENSAJE_ERROR)
            VALUES(:Id_Usuario,:Username,:Modulo,:Accion,:Tabla_Afectada,
            :Id_Registro,:Descripcion,:Datos_Anteriores,:Datos_Nuevos,:Ip_Origen,:Resultado,:Mensaje_Error)", r);
        }

    }
}
