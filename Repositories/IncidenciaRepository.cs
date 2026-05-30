using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class IncidenciaRepository : IIncidenciaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public IncidenciaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<IncidenciaModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                ID_INCIDENCIA IdIncidencia,
                ID_PROPIEDAD IdPropiedad,
                ID_ESPACIO IdEspacio,
                ID_CATEGORIA IdCategoria,
                ID_REPORTADO_POR IdReportadoPor,
                TITULO Titulo,
                DESCRIPCION Descripcion,
                PRIORIDAD Prioridad,
                ESTADO Estado,
                ID_ASIGNADO_A IdAsignadoA,
                ID_PROVEEDOR IdProveedor,
                COSTO_ESTIMADO CostoEstimado,
                COSTO_REAL CostoReal,
                ID_FACTURA_CARGO IdFacturaCargo,
                FECHA_APERTURA FechaApertura,
                FECHA_RESOLUCION FechaResolucion,
                OBSERVACIONES Observaciones
              FROM INCIDENCIA";

            return (await db.QueryAsync<IncidenciaModel>(query)).ToList();
        }

        public async Task<IncidenciaModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                            ID_INCIDENCIA IdIncidencia,
                            ID_PROPIEDAD IdPropiedad,
                            ID_ESPACIO IdEspacio,
                            ID_CATEGORIA IdCategoria,
                            ID_REPORTADO_POR IdReportadoPor,
                            TITULO Titulo,
                            DESCRIPCION Descripcion,
                            PRIORIDAD Prioridad,
                            ESTADO Estado,
                            ID_ASIGNADO_A IdAsignadoA,
                            ID_PROVEEDOR IdProveedor,
                            COSTO_ESTIMADO CostoEstimado,
                            COSTO_REAL CostoReal,
                            ID_FACTURA_CARGO IdFacturaCargo,
                            FECHA_APERTURA FechaApertura,
                            FECHA_RESOLUCION FechaResolucion,
                            OBSERVACIONES Observaciones
                          FROM INCIDENCIA
                          WHERE ID_INCIDENCIA = :id";

            return await db.QueryFirstOrDefaultAsync<IncidenciaModel>(query, new { id });
        }

        public async Task CreateAsync(IncidenciaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO INCIDENCIA
                  (ID_PROPIEDAD, ID_ESPACIO, ID_CATEGORIA, ID_REPORTADO_POR, 
                   TITULO, DESCRIPCION, PRIORIDAD, ESTADO, ID_ASIGNADO_A, 
                   ID_PROVEEDOR, COSTO_ESTIMADO, COSTO_REAL, ID_FACTURA_CARGO, 
                   FECHA_APERTURA, FECHA_RESOLUCION, OBSERVACIONES)
                  VALUES
                  (:IdPropiedad, :IdEspacio, :IdCategoria, :IdReportadoPor,
                   :Titulo, :Descripcion, :Prioridad, :Estado, :IdAsignadoA,
                   :IdProveedor, :CostoEstimado, :CostoReal, :IdFacturaCargo,
                   :FechaApertura, :FechaResolucion, :Observaciones)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(IncidenciaModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE INCIDENCIA SET
                  ID_PROPIEDAD = :IdPropiedad,
                  ID_ESPACIO = :IdEspacio,
                  ID_CATEGORIA = :IdCategoria,
                  ID_REPORTADO_POR = :IdReportadoPor,
                  TITULO = :Titulo,
                  DESCRIPCION = :Descripcion,
                  PRIORIDAD = :Prioridad,
                  ESTADO = :Estado,
                  ID_ASIGNADO_A = :IdAsignadoA,
                  ID_PROVEEDOR = :IdProveedor,
                  COSTO_ESTIMADO = :CostoEstimado,
                  COSTO_REAL = :CostoReal,
                  ID_FACTURA_CARGO = :IdFacturaCargo,
                  FECHA_APERTURA = :FechaApertura,
                  FECHA_RESOLUCION = :FechaResolucion,
                  OBSERVACIONES = :Observaciones
                  WHERE ID_INCIDENCIA = :IdIncidencia";

            await db.ExecuteAsync(query, model);
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM INCIDENCIA WHERE ID_INCIDENCIA = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}