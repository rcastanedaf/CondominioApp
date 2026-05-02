using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class ReservaEspacioRepository : IReservaEspacioRepository
    {
        private readonly string _conn;
        public ReservaEspacioRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;

        public async Task<List<ReservaEspacioModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_conn);
            return (await db.QueryAsync<ReservaEspacioModel>(@"SELECT ID_RESERVA Id_Reserva,ID_ESPACIO Id_Espacio,
            ID_RESIDENTE Id_Residente,ID_PROPIEDAD Id_Propiedad,
            TO_CHAR(FECHA_RESERVA,'YYYY-MM-DD') Fecha_Reserva,
            HORA_INICIO Hora_Inicio,HORA_FIN Hora_Fin,NUM_PERSONAS Num_Personas,
            MOTIVO,ESTADO,MONTO_COBRO Monto_Cobro,DEPOSITO_COBRADO Deposito_Cobrado,
            DEPOSITO_DEVUELTO Deposito_Devuelto,ID_FACTURA Id_Factura,
            APROBADO_POR Aprobado_Por,OBSERVACIONES,
            TO_CHAR(FECHA_REGISTRO,'YYYY-MM-DD') Fecha_Registro
            FROM RESERVA_ESPACIO ORDER BY FECHA_RESERVA DESC")).ToList();
        }

        public async Task<List<ReservaEspacioModel>> GetByEspacio(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            return (await db.QueryAsync<ReservaEspacioModel>("SELECT * FROM RESERVA_ESPACIO WHERE ID_ESPACIO=:id ORDER BY FECHA_RESERVA DESC", new { id })).ToList();
        }

        public async Task<List<ReservaEspacioModel>> GetByResidente(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            return (await db.QueryAsync<ReservaEspacioModel>("SELECT * FROM RESERVA_ESPACIO WHERE ID_RESIDENTE=:id ORDER BY FECHA_RESERVA DESC", new { id })).ToList();
        }

        public async Task<ReservaEspacioCreateRequest> Create(ReservaEspacioCreateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync(@"INSERT INTO RESERVA_ESPACIO(ID_ESPACIO,ID_RESIDENTE,ID_PROPIEDAD,FECHA_RESERVA,
            HORA_INICIO,HORA_FIN,NUM_PERSONAS,MOTIVO,MONTO_COBRO,DEPOSITO_COBRADO,OBSERVACIONES)
            VALUES(:Id_Espacio,:Id_Residente,:Id_Propiedad,TO_DATE(:Fecha_Reserva,'YYYY-MM-DD'),
            :Hora_Inicio,:Hora_Fin,:Num_Personas,:Motivo,:Monto_Cobro,:Deposito_Cobrado,:Observaciones)", r);
            return r;
        }

        public async Task<ReservaEspacioUpdateRequest> Update(ReservaEspacioUpdateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync(@"UPDATE RESERVA_ESPACIO SET ESTADO=:Estado,MONTO_COBRO=:Monto_Cobro,
            DEPOSITO_COBRADO=:Deposito_Cobrado,DEPOSITO_DEVUELTO=:Deposito_Devuelto,
            APROBADO_POR=:Aprobado_Por,OBSERVACIONES=:Observaciones
            WHERE ID_RESERVA=:Id_Reserva", r);
            return r;
        }

        public async Task<bool> CambiarEstado(int id, string estado, int? aprobadoPor)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("UPDATE RESERVA_ESPACIO SET ESTADO=:estado,APROBADO_POR=:aprobadoPor WHERE ID_RESERVA=:id", new { estado, aprobadoPor, id });
            return true;
        }

    }
}
