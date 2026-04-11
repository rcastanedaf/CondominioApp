using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class MultaRepository : IMultaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public MultaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<Multa>> GetAllAsync()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM Multa";

                    var result = (await db.QueryAsync<Multa>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Multa>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Multa>> GetId(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM Multa WHERE id_multa = :Id";

                    var result = (await db.QueryAsync<Multa>(query, new { Id = id })).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Multa>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Multa>> GetNombre(string nombre)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM Multa WHERE nombre = :Nombre";

                    var result = (await db.QueryAsync<Multa>(query, new { Nombre = nombre })).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Multa>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MultaCreateRequest> CreateMulta(MultaCreateRequest newMulta)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = @"
INSERT INTO Multa(
    id_residente, id_propiedad, id_tipo_infraccion, descripcion, monto, fecha_infraccion, fecha_vencimiento,
    estado, evidencia, id_factura, id_apelacion, id_emitida, id_aprobada, observaciones, fecha_registro
)
VALUES(
    :Id_Residente, :Id_Propiedad, :Id_Tipo_Infraccion, :Descripcion, :Monto, :Fecha_Infraccion, :Fecha_Vencimiento,
    :Estado, :Evidencia, :Id_Factura, :Id_Apelacion, :Id_Emitida, :Id_Aprobada, :Observaciones, :Fecha_Registro
)";

                    var parameters = new
                    {
                        newMulta.Id_Residente,
                        newMulta.Id_Propiedad,
                        newMulta.Id_Tipo_Infraccion,
                        newMulta.Descripcion,
                        newMulta.Monto,
                        newMulta.Fecha_Infraccion,
                        newMulta.Fecha_Vencimiento,
                        newMulta.Estado,
                        newMulta.Evidencia,
                        newMulta.Id_Factura,
                        newMulta.Id_Apelacion,
                        newMulta.Id_Emitida,
                        newMulta.Id_Aprobada, // CORREGIDO: "aprobada" con 'b'
                        newMulta.Observaciones,
                        newMulta.Fecha_Registro
                    };

                    await db.ExecuteAsync(query, parameters);

                    return newMulta;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MultaUpdateRequest> UpdateMulta(MultaUpdateRequest editMulta)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = @"
UPDATE Multa SET
    id_residente     = :Id_Residente,
    id_propiedad     = :Id_Propiedad,
    descripcion      = :Descripcion,
    monto            = :Monto,
    fecha_infraccion = :Fecha_Infraccion,
    fecha_vencimiento= :Fecha_Vencimiento,
    estado           = :Estado,
    evidencia_url        = :Evidencia,
    id_factura       = :Id_Factura,
    id_apelacion     = :Id_Apelacion,
    emitida_por       = :Id_Emitida,
    aprobada_por      = :Id_Aprobada,
    observaciones    = :Observaciones
WHERE id_multa = :Id_Multa";

                    var parameters = new
                    {
                        Id_Residente = editMulta.Id_Residente,
                        Id_Propiedad = editMulta.Id_Propiedad,
                        Descripcion = editMulta.Descripcion,
                        Monto = editMulta.Monto,
                        Fecha_Infraccion = editMulta.Fecha_Infraccion,
                        Fecha_Vencimiento = editMulta.Fecha_Vencimiento,
                        Estado = editMulta.Estado,
                        Evidencia = editMulta.Evidencia,
                        Id_Factura = editMulta.Id_Factura,
                        Id_Apelacion = editMulta.Id_Apelacion,
                        Id_Emitida = 1,
                        Id_Aprobada = editMulta.Id_Aprobada,
                        Observaciones = editMulta.Observaciones,
                        Id_Multa = editMulta.Id_Multa
                    };

                    await db.ExecuteAsync(query, parameters);

                    return editMulta;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteMulta(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "DELETE FROM Multa WHERE id_multa = :Id";

                    await db.ExecuteAsync(query, new { Id = id });

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
