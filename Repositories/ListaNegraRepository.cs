using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class ListaNegraRepository : IListaNegraRepository
    {
        private readonly string _conn;
        public ListaNegraRepository(IConfiguration cfg) => _conn = cfg.GetConnectionString("DefaultConnection")!;

        public async Task<List<ListaNegraModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_conn);
            return (await db.QueryAsync<ListaNegraModel>(@"SELECT ID_LISTA Id_Lista,TIPO,ID_PERSONA Id_Persona,PLACA,
                        NOMBRES,DPI,MOTIVO,ACTIVO,REGISTRADO_POR Registrado_Por,
                        TO_CHAR(FECHA_INICIO,'YYYY-MM-DD') Fecha_Inicio,
                        TO_CHAR(FECHA_FIN,'YYYY-MM-DD') Fecha_Fin,OBSERVACIONES
                        FROM LISTA_NEGRA ORDER BY FECHA_REGISTRO DESC")).ToList();
        }

        public async Task<ListaNegraModel> GetById(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            return await db.QueryFirstOrDefaultAsync<ListaNegraModel>("SELECT * FROM LISTA_NEGRA WHERE ID_LISTA=:id", new { id });
        }

        public async Task<ListaNegraCreateRequest> Create(ListaNegraCreateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"INSERT INTO LISTA_NEGRA(TIPO,ID_PERSONA,PLACA,NOMBRES,DPI,MOTIVO,ACTIVO,REGISTRADO_POR,FECHA_INICIO,FECHA_FIN,OBSERVACIONES)
                    VALUES(:Tipo,:Id_Persona,:Placa,:Nombres,:Dpi,:Motivo,:Activo,:Registrado_Por,
                    TO_DATE(:Fecha_Inicio,'YYYY-MM-DD'),TO_DATE(:Fecha_Fin,'YYYY-MM-DD'),:Observaciones)";
            await db.ExecuteAsync(sql, r);
            return r;
        }

        public async Task<ListaNegraUpdateRequest> Update(ListaNegraUpdateRequest r)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = @"UPDATE LISTA_NEGRA SET TIPO=:Tipo,ID_PERSONA=:Id_Persona,PLACA=:Placa,NOMBRES=:Nombres,
                    DPI=:Dpi,MOTIVO=:Motivo,ACTIVO=:Activo,FECHA_INICIO=TO_DATE(:Fecha_Inicio,'YYYY-MM-DD'),
                    FECHA_FIN=TO_DATE(:Fecha_Fin,'YYYY-MM-DD'),OBSERVACIONES=:Observaciones
                    WHERE ID_LISTA=:Id_Lista";
            await db.ExecuteAsync(sql, r);
            return r;
        }

        public async Task<bool> Desactivar(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            await db.ExecuteAsync("UPDATE LISTA_NEGRA SET ACTIVO=0 WHERE ID_LISTA=:id", new { id });
            return true;
        }

    }
}
