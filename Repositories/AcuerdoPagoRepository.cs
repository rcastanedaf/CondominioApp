using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class AcuerdoPagoRepository : IAcuerdoPagoRepository
    {
        private readonly string _conn;

        public AcuerdoPagoRepository(IConfiguration configuration)
        {
            _conn = configuration.GetConnectionString("DefaultConnection")!;
        }

        private const string SELECT_FIELDS = @"
            SELECT a.ID_ACUERDO     AS IdAcuerdo,
                   a.ID_RESIDENTE   AS IdResidente,
                   a.ID_CUENTA      AS IdCuenta,
                   a.DESCRIPCION    AS Descripcion,
                   a.MONTO_TOTAL    AS MontoTotal,
                   a.MONTO_CUOTA    AS MontoCuota,
                   a.NUM_CUOTAS     AS NumCuotas,
                   a.DIA_PAGO       AS DiaPago,
                   a.FECHA_INICIO   AS FechaInicio,
                   a.ESTADO         AS Estado,
                   a.APROBADO_POR   AS AprobadoPor,
                   a.OBSERVACIONES  AS Observaciones,
                   a.FECHA_REGISTRO AS FechaRegistro,
                   p.NOMBRES || ' ' || p.APELLIDOS AS NombreResidente
            FROM ACUERDO_PAGO a
            JOIN RESIDENTE r ON r.ID_RESIDENTE = a.ID_RESIDENTE
            JOIN PERSONA   p ON p.ID_PERSONA   = r.ID_PERSONA";

        public async Task<IEnumerable<AcuerdoPagoModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = $"{SELECT_FIELDS} ORDER BY a.FECHA_INICIO DESC";
            return await db.QueryAsync<AcuerdoPagoModel>(sql);
        }

        public async Task<IEnumerable<AcuerdoPagoModel>> GetByResidenteAsync(int idResidente)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = $"{SELECT_FIELDS} WHERE a.ID_RESIDENTE = :idResidente ORDER BY a.FECHA_INICIO DESC";
            return await db.QueryAsync<AcuerdoPagoModel>(sql, new { idResidente });
        }

        public async Task<AcuerdoPagoModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            var sql = $"{SELECT_FIELDS} WHERE a.ID_ACUERDO = :id";
            return await db.QueryFirstOrDefaultAsync<AcuerdoPagoModel>(sql, new { id });
        }

        public async Task<int> CreateAsync(AcuerdoPagoCreateRequest request)
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = @"
                INSERT INTO ACUERDO_PAGO
                    (ID_RESIDENTE, ID_CUENTA, DESCRIPCION, MONTO_TOTAL, MONTO_CUOTA,
                     NUM_CUOTAS, DIA_PAGO, FECHA_INICIO, ESTADO, APROBADO_POR, OBSERVACIONES)
                VALUES
                    (:IdResidente, :IdCuenta, :Descripcion, :MontoTotal, :MontoCuota,
                     :NumCuotas, :DiaPago, :FechaInicio, 'ACTIVO', :AprobadoPor, :Observaciones)";
            return await db.ExecuteAsync(sql, request);
        }

        public async Task<int> UpdateAsync(int id, AcuerdoPagoUpdateRequest request)
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = @"
                UPDATE ACUERDO_PAGO
                SET ESTADO        = :Estado,
                    OBSERVACIONES = :Observaciones
                WHERE ID_ACUERDO  = :id";
            return await db.ExecuteAsync(sql, new { request.Estado, request.Observaciones, id });
        }

        public async Task<int> DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = "DELETE FROM ACUERDO_PAGO WHERE ID_ACUERDO = :id";
            return await db.ExecuteAsync(sql, new { id });
        }

        public async Task<IEnumerable<CuotaAcuerdoModel>> GetCuotasAsync(int idAcuerdo)
        {
            using IDbConnection db = new OracleConnection(_conn);
            const string sql = @"
                SELECT ID_CUOTA          AS IdCuota,
                       ID_ACUERDO        AS IdAcuerdo,
                       NUMERO_CUOTA      AS NumeroCuota,
                       FECHA_VENCIMIENTO AS FechaVencimiento,
                       MONTO             AS Monto,
                       FECHA_PAGO        AS FechaPago,
                       ESTADO            AS Estado,
                       ID_PAGO           AS IdPago
                FROM CUOTA_ACUERDO
                WHERE ID_ACUERDO = :idAcuerdo
                ORDER BY NUMERO_CUOTA";
            return await db.QueryAsync<CuotaAcuerdoModel>(sql, new { idAcuerdo });
        }

        public async Task<int> PagarCuotaAsync(int idCuota)
        {
            using IDbConnection db = new OracleConnection(_conn);
            // Estado correcto según constraint: 'PAGADA' no 'PAGADO'
            const string sql = @"
                UPDATE CUOTA_ACUERDO
                SET ESTADO     = 'PAGADA',
                    FECHA_PAGO = SYSDATE
                WHERE ID_CUOTA = :idCuota";
            return await db.ExecuteAsync(sql, new { idCuota });
        }
    }
}