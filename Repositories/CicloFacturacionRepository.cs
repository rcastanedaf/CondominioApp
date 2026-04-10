using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class CicloFacturacionRepository : ICicloFacturacionRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public CicloFacturacionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<CicloFacturacionModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_CICLO           IdCiclo,
                            ID_PROPIEDAD       IdPropiedad,
                            ID_TIPO_SERVICIO   IdTipoServicio,
                            DIA_CORTE          DiaCorte,
                            DIA_VENCIMIENTO    DiaVencimiento,
                            MONTO_OVERRIDE     MontoOverride,
                            ACTIVO             Activo,
                            FECHA_INICIO       FechaInicio,
                            FECHA_FIN          FechaFin
                          FROM CICLO_FACTURACION";

            return (await db.QueryAsync<CicloFacturacionModel>(query)).ToList();
        }

        public async Task<CicloFacturacionModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_CICLO           IdCiclo,
                            ID_PROPIEDAD       IdPropiedad,
                            ID_TIPO_SERVICIO   IdTipoServicio,
                            DIA_CORTE          DiaCorte,
                            DIA_VENCIMIENTO    DiaVencimiento,
                            MONTO_OVERRIDE     MontoOverride,
                            ACTIVO             Activo,
                            FECHA_INICIO       FechaInicio,
                            FECHA_FIN          FechaFin
                          FROM CICLO_FACTURACION
                          WHERE ID_CICLO = :id";

            return await db.QueryFirstOrDefaultAsync<CicloFacturacionModel>(query, new { id });
        }

        public async Task<List<CicloFacturacionModel>> GetByPropiedadAsync(int idPropiedad)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT
                            ID_CICLO           IdCiclo,
                            ID_PROPIEDAD       IdPropiedad,
                            ID_TIPO_SERVICIO   IdTipoServicio,
                            DIA_CORTE          DiaCorte,
                            DIA_VENCIMIENTO    DiaVencimiento,
                            MONTO_OVERRIDE     MontoOverride,
                            ACTIVO             Activo,
                            FECHA_INICIO       FechaInicio,
                            FECHA_FIN          FechaFin
                          FROM CICLO_FACTURACION
                          WHERE ID_PROPIEDAD = :idPropiedad";

            return (await db.QueryAsync<CicloFacturacionModel>(query, new { idPropiedad })).ToList();
        }

        public async Task CreateAsync(CicloFacturacionModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO CICLO_FACTURACION
                          (ID_PROPIEDAD, ID_TIPO_SERVICIO, DIA_CORTE, DIA_VENCIMIENTO,
                           MONTO_OVERRIDE, ACTIVO, FECHA_INICIO, FECHA_FIN)
                          VALUES
                          (:IdPropiedad, :IdTipoServicio, :DiaCorte, :DiaVencimiento,
                           :MontoOverride, :Activo, :FechaInicio, :FechaFin)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(CicloFacturacionModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE CICLO_FACTURACION SET
                          ID_PROPIEDAD     = :IdPropiedad,
                          ID_TIPO_SERVICIO = :IdTipoServicio,
                          DIA_CORTE        = :DiaCorte,
                          DIA_VENCIMIENTO  = :DiaVencimiento,
                          MONTO_OVERRIDE   = :MontoOverride,
                          ACTIVO           = :Activo,
                          FECHA_INICIO     = :FechaInicio,
                          FECHA_FIN        = :FechaFin
                          WHERE ID_CICLO = :IdCiclo";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM CICLO_FACTURACION WHERE ID_CICLO = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}
