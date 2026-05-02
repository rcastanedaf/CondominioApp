using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class EspacioComunRepository : IEspacioComunRepository
    {
        private readonly string _conn;
        public EspacioComunRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;

        public async Task<List<EspacioComunModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_conn);
            return (await db.QueryAsync<EspacioComunModel>(@"SELECT ID_ESPACIO Id_Espacio,NOMBRE,DESCRIPCION,
            CAPACIDAD_MAX Capacidad_Max,REQUIERE_RESERVA Requiere_Reserva,
            TIENE_COSTO Tiene_Costo,COSTO_POR_HORA Costo_Por_Hora,
            COSTO_POR_DIA Costo_Por_Dia,DEPOSITO_GARANTIA Deposito_Garantia,
            HORARIO_APERTURA Horario_Apertura,HORARIO_CIERRE Horario_Cierre,
            REGLAS,ESTADO,ACTIVO FROM ESPACIO_COMUN ORDER BY NOMBRE")).ToList();
        }

        public async Task<EspacioComunCreateRequest> Create(EspacioComunCreateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync(@"INSERT INTO ESPACIO_COMUN(NOMBRE,DESCRIPCION,CAPACIDAD_MAX,REQUIERE_RESERVA,
            TIENE_COSTO,COSTO_POR_HORA,COSTO_POR_DIA,DEPOSITO_GARANTIA,
            HORARIO_APERTURA,HORARIO_CIERRE,REGLAS,ESTADO,ACTIVO)
            VALUES(:Nombre,:Descripcion,:Capacidad_Max,:Requiere_Reserva,
            :Tiene_Costo,:Costo_Por_Hora,:Costo_Por_Dia,:Deposito_Garantia,
            :Horario_Apertura,:Horario_Cierre,:Reglas,:Estado,:Activo)", r);
            return r;
        }

        public async Task<EspacioComunUpdateRequest> Update(EspacioComunUpdateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync(@"UPDATE ESPACIO_COMUN SET NOMBRE=:Nombre,DESCRIPCION=:Descripcion,
            CAPACIDAD_MAX=:Capacidad_Max,REQUIERE_RESERVA=:Requiere_Reserva,
            TIENE_COSTO=:Tiene_Costo,COSTO_POR_HORA=:Costo_Por_Hora,
            COSTO_POR_DIA=:Costo_Por_Dia,DEPOSITO_GARANTIA=:Deposito_Garantia,
            HORARIO_APERTURA=:Horario_Apertura,HORARIO_CIERRE=:Horario_Cierre,
            REGLAS=:Reglas,ESTADO=:Estado,ACTIVO=:Activo
            WHERE ID_ESPACIO=:Id_Espacio", r);
            return r;
        }

        public async Task<bool> CambiarEstado(int id, string estado)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("UPDATE ESPACIO_COMUN SET ESTADO=:estado WHERE ID_ESPACIO=:id", new { estado, id });
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("UPDATE ESPACIO_COMUN SET ACTIVO=0 WHERE ID_ESPACIO=:id", new { id });
            return true;
        }

    }
}
