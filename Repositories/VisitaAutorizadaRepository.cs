using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class VisitaAutorizadaRepository : IVisitaAutorizadaRepository
    {
        private readonly string _conn;
        public VisitaAutorizadaRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;

        public async Task<List<VisitaAutorizadaModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"SELECT ID_VISITA Id_Visita, ID_RESIDENTE Id_Residente, ID_PROPIEDAD Id_Propiedad,
                    ID_MOTIVO_VISITA Id_Motivo_Visita, NOMBRE_VISITANTE Nombre_Visitante,
                    DPI_VISITANTE Dpi_Visitante, PLACA_VEHICULO Placa_Vehiculo,
                    TO_CHAR(FECHA_DESDE,'YYYY-MM-DD') Fecha_Desde,
                    TO_CHAR(FECHA_HASTA,'YYYY-MM-DD') Fecha_Hasta,
                    HORA_DESDE, HORA_HASTA, TIPO, ESTADO, OBSERVACIONES
                    FROM VISITA_AUTORIZADA ORDER BY FECHA_DESDE DESC";
            return (await db.QueryAsync<VisitaAutorizadaModel>(sql)).ToList();
        }

        public async Task<List<VisitaAutorizadaModel>> GetActivas()
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = "SELECT * FROM VISITA_AUTORIZADA WHERE ESTADO='ACTIVA' AND FECHA_DESDE <= SYSDATE AND (FECHA_HASTA IS NULL OR FECHA_HASTA >= SYSDATE)";
            return (await db.QueryAsync<VisitaAutorizadaModel>(sql)).ToList();
        }

        public async Task<VisitaAutorizadaModel> GetById(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            return await db.QueryFirstOrDefaultAsync<VisitaAutorizadaModel>("SELECT * FROM VISITA_AUTORIZADA WHERE ID_VISITA=:id", new { id });
        }

        public async Task<VisitaAutorizadaCreateRequest> Create(VisitaAutorizadaCreateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"INSERT INTO VISITA_AUTORIZADA(ID_RESIDENTE,ID_PROPIEDAD,ID_MOTIVO_VISITA,NOMBRE_VISITANTE,
                    DPI_VISITANTE,PLACA_VEHICULO,FECHA_DESDE,FECHA_HASTA,HORA_DESDE,HORA_HASTA,TIPO,ESTADO,OBSERVACIONES)
                    VALUES(:Id_Residente,:Id_Propiedad,:Id_Motivo_Visita,:Nombre_Visitante,
                    :Dpi_Visitante,:Placa_Vehiculo,TO_DATE(:Fecha_Desde,'YYYY-MM-DD'),TO_DATE(:Fecha_Hasta,'YYYY-MM-DD'),
                    :Hora_Desde,:Hora_Hasta,:Tipo,:Estado,:Observaciones)";
            await db.ExecuteAsync(sql, r);
            return r;
        }

        public async Task<VisitaAutorizadaUpdateRequest> Update(VisitaAutorizadaUpdateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"UPDATE VISITA_AUTORIZADA SET ID_RESIDENTE=:Id_Residente, ID_PROPIEDAD=:Id_Propiedad,
                    ID_MOTIVO_VISITA=:Id_Motivo_Visita, NOMBRE_VISITANTE=:Nombre_Visitante,
                    DPI_VISITANTE=:Dpi_Visitante, PLACA_VEHICULO=:Placa_Vehiculo,
                    FECHA_DESDE=TO_DATE(:Fecha_Desde,'YYYY-MM-DD'),
                    FECHA_HASTA=TO_DATE(:Fecha_Hasta,'YYYY-MM-DD'),
                    HORA_DESDE=:Hora_Desde, HORA_HASTA=:Hora_Hasta,
                    TIPO=:Tipo, ESTADO=:Estado, OBSERVACIONES=:Observaciones
                    WHERE ID_VISITA=:Id_Visita";
            await db.ExecuteAsync(sql, r);
            return r;
        }

        public async Task<bool> CambiarEstado(int id, string estado)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("UPDATE VISITA_AUTORIZADA SET ESTADO=:estado WHERE ID_VISITA=:id", new { estado, id });
            return true;
        }
    }

}
