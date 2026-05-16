using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class RegistroAccesoRepository : IRegistroAccesoRepository
    {
        private readonly string _conn;
        public RegistroAccesoRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;

        public async Task<List<RegistroAccesoModel>> GetAllAsync(int? top = 200)
        {
            using IDbConnection db = new OracleConnection(_conn);
            int limite = top > 0 ? top.Value : 200;
            const string sql = @"
        SELECT * FROM (
            SELECT ID_REGISTRO           AS Id_Acceso,
                   TIPO_MOVIMIENTO     AS Tipo_Movimiento,
                   TIPO_PERSONA        AS Tipo_Persona,
                   ID_RESIDENTE        AS Id_Residente,
                   ID_VISITANTE           AS Id_Visita,
                   ID_EMPLEADO         AS Id_Empleado,
                   NOMBRE_PERSONA      AS Nombre_Persona,
                   DPI_PERSONA         AS Dpi_Persona,
                   PLACA_VEHICULO      AS Placa_Vehiculo,
                   PUNTO_ACCESO        AS Punto_Acceso,
                   AUTORIZADO_POR      AS Autorizado_Por,
                   OBSERVACIONES,
                   TO_CHAR(FECHA_HORA, 'YYYY-MM-DD HH24:MI:SS') AS Fecha_Hora
            FROM REGISTRO_ACCESO
            ORDER BY FECHA_HORA DESC
        ) WHERE ROWNUM <= :limite";
            return (await db.QueryAsync<RegistroAccesoModel>(sql, new { limite })).ToList();
        }

        public async Task<List<RegistroAccesoModel>> GetByFecha(string desde, string hasta)
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = @"
                    SELECT ID_ACCESO           AS Id_Acceso,
                           TIPO_MOVIMIENTO     AS Tipo_Movimiento,
                           TIPO_PERSONA        AS Tipo_Persona,
                           ID_RESIDENTE        AS Id_Residente,
                           ID_VISITANTE        AS Id_Visitante,
                           ID_EMPLEADO         AS Id_Empleado,
                           NOMBRE_PERSONA      AS Nombre_Persona,
                           DPI_PERSONA         AS Dpi_Persona,
                           PLACA_VEHICULO      AS Placa_Vehiculo,
                           PUNTO_ACCESO        AS Punto_Acceso,
                           AUTORIZADO_POR      AS Autorizado_Por,
                           OBSERVACIONES,
                           TO_CHAR(FECHA_HORA, 'YYYY-MM-DD HH24:MI:SS') AS Fecha_Hora
                    FROM REGISTRO_ACCESO
                    WHERE TRUNC(FECHA_HORA) BETWEEN TO_DATE(:desde, 'YYYY-MM-DD')
                                                AND TO_DATE(:hasta, 'YYYY-MM-DD')
                    ORDER BY FECHA_HORA DESC";
            return (await db.QueryAsync<RegistroAccesoModel>(sql, new { desde, hasta })).ToList();
        }

        public async Task<RegistroAccesoCreateRequest> Create(RegistroAccesoCreateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"INSERT INTO REGISTRO_ACCESO(TIPO_MOVIMIENTO,TIPO_PERSONA,ID_RESIDENTE,ID_VISITANTE,ID_EMPLEADO,
                    NOMBRE_PERSONA,DPI_PERSONA,PLACA_VEHICULO,PUNTO_ACCESO,AUTORIZADO_POR,OBSERVACIONES)
                    VALUES(:Tipo_Movimiento,:Tipo_Persona,:Id_Residente,:Id_Visitante,:Id_Empleado,
                    :Nombre_Persona,:Dpi_Persona,:Placa_Vehiculo,:Punto_Accedo,:Autorizado_Por,:Observaciones)";
            await db.ExecuteAsync(sql, r);
            return r;
        }

    }
}
