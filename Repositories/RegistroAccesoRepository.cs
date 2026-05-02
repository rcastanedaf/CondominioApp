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
            var sql = $@"SELECT * FROM (
                    SELECT ID_ACCESO Id_Acceso, TIPO_MOVIMIENTO Tipo_Movimiento,
                    TIPO_PERSONA Tipo_Persona, ID_RESIDENTE Id_Residente,
                    ID_VISITA Id_Visita, ID_VEHICULO Id_Vehiculo,
                    NOMBRE_PERSONA Nombre_Persona, DPI_PERSONA Dpi_Persona,
                    PLACA_VEHICULO Placa_Vehiculo, ID_PROPIEDAD Id_Propiedad,
                    ID_MOTIVO_VISITA Id_Motivo_Visita, OBSERVACIONES, REGISTRADO_POR Registrado_Por,
                    TO_CHAR(FECHA_HORA,'YYYY-MM-DD HH24:MI:SS') Fecha_Hora
                    FROM REGISTRO_ACCESO ORDER BY FECHA_HORA DESC
                    ) WHERE ROWNUM <= {top ?? 200}";
            return (await db.QueryAsync<RegistroAccesoModel>(sql)).ToList();
        }

        public async Task<List<RegistroAccesoModel>> GetByFecha(string desde, string hasta)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"SELECT * FROM REGISTRO_ACCESO
                    WHERE TRUNC(FECHA_HORA) BETWEEN TO_DATE(:desde,'YYYY-MM-DD') AND TO_DATE(:hasta,'YYYY-MM-DD')
                    ORDER BY FECHA_HORA DESC";
            return (await db.QueryAsync<RegistroAccesoModel>(sql, new { desde, hasta })).ToList();
        }

        public async Task<RegistroAccesoCreateRequest> Create(RegistroAccesoCreateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"INSERT INTO REGISTRO_ACCESO(TIPO_MOVIMIENTO,TIPO_PERSONA,ID_RESIDENTE,ID_VISITA,ID_VEHICULO,
                    NOMBRE_PERSONA,DPI_PERSONA,PLACA_VEHICULO,ID_PROPIEDAD,ID_MOTIVO_VISITA,OBSERVACIONES,REGISTRADO_POR)
                    VALUES(:Tipo_Movimiento,:Tipo_Persona,:Id_Residente,:Id_Visita,:Id_Vehiculo,
                    :Nombre_Persona,:Dpi_Persona,:Placa_Vehiculo,:Id_Propiedad,:Id_Motivo_Visita,:Observaciones,:Registrado_Por)";
            await db.ExecuteAsync(sql, r);
            return r;
        }

    }
}
