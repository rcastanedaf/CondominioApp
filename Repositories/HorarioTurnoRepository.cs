using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace Condominio.Repositories
{
    public class HorarioTurnoRepository : IHorarioTurnoRepository
    {
        private readonly IDbConnection _db;

        public HorarioTurnoRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<HorarioTurnoModel>> GetAllAsync()
        {
            const string sql = @"
            SELECT ID_TURNO    AS IdTurno,
                    NOMBRE      AS Nombre,
                    HORA_INICIO AS HoraInicio,
                    HORA_FIN    AS HoraFin,
                    DIAS_SEMANA AS DiasSemana,
                    ACTIVO      AS Activo
            FROM HORARIO_TURNO
            ORDER BY ID_TURNO";
            return await _db.QueryAsync<HorarioTurnoModel>(sql);
        }

        public async Task<HorarioTurnoModel?> GetByIdAsync(int id)
        {
            const string sql = @"
            SELECT ID_TURNO    AS IdTurno,
                    NOMBRE      AS Nombre,
                    HORA_INICIO AS HoraInicio,
                    HORA_FIN    AS HoraFin,
                    DIAS_SEMANA AS DiasSemana,
                    ACTIVO      AS Activo
            FROM HORARIO_TURNO
            WHERE ID_TURNO = :id";
            return await _db.QueryFirstOrDefaultAsync<HorarioTurnoModel>(sql, new { id });
        }

        public async Task<int> CreateAsync(HorarioTurnoModel model)
        {
            const string sql = @"
            INSERT INTO HORARIO_TURNO (NOMBRE, HORA_INICIO, HORA_FIN, DIAS_SEMANA, ACTIVO)
            VALUES (:Nombre, :HoraInicio, :HoraFin, :DiasSemana, :Activo)";
            return await _db.ExecuteAsync(sql, model);
        }

        public async Task<int> UpdateAsync(HorarioTurnoModel model)
        {
            const string sql = @"
            UPDATE HORARIO_TURNO
            SET NOMBRE      = :Nombre,
                HORA_INICIO = :HoraInicio,
                HORA_FIN    = :HoraFin,
                DIAS_SEMANA = :DiasSemana,
                ACTIVO      = :Activo
            WHERE ID_TURNO = :IdTurno";
            return await _db.ExecuteAsync(sql, model);
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM HORARIO_TURNO WHERE ID_TURNO = :id";
            return await _db.ExecuteAsync(sql, new { id });
        }

        public async Task<int> ToggleActivoAsync(int id, int activo)
        {
            const string sql = @"
            UPDATE HORARIO_TURNO SET ACTIVO = :activo WHERE ID_TURNO = :id";
            return await _db.ExecuteAsync(sql, new { activo, id });
        }
    }
}
