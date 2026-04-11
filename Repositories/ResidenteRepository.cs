using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class ResidenteRepository : IResidenteRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public ResidenteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<List<Residente>> GetAllAsync()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = @"SELECT
                        ID_RESIDENTE    Id_Residente,
                        ID_PERSONA      Id_Persona,
                        ID_PROPIEDAD    Id_Propiedad,
                        TIPO_RESIDENTE  Tipo_Residente,
                        FECHA_INGRESO   Fecha_Ingreso,
                        FECHA_SALIDA    Fecha_Salida,
                        ACTIVO          Activo,
                        OBSERVACIONES   Observaciones
                      FROM RESIDENTE";

                    var result = (await db.QueryAsync<Residente>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Residente>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Residente>> GetId(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Residente WHERE id_residente = {id}";

                    var result = (await db.QueryAsync<Residente>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Residente>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Residente>> GetNombre(string nombre)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Residente WHERE nombre = {nombre}";

                    var result = (await db.QueryAsync<Residente>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Residente>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResidenteCreateRequest> CreateResidente(ResidenteCreateRequest newResidente)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = @"INSERT INTO RESIDENTE
                      (ID_PERSONA, ID_PROPIEDAD, TIPO_RESIDENTE,
                       FECHA_INGRESO, FECHA_SALIDA, ACTIVO, OBSERVACIONES)
                      VALUES
                      (:Id_Persona, :Id_Propiedad, :Tipo_Residente,
                       TO_DATE(:Fecha_Ingreso, 'YYYY-MM-DD'),
                       CASE WHEN :Fecha_Salida IS NULL THEN NULL
                            ELSE TO_DATE(:Fecha_Salida, 'YYYY-MM-DD') END,
                       :Activo, :Observaciones)";
                await db.ExecuteAsync(query, newResidente);
                return newResidente;
            }
        }
        public async Task<ResidenteUpdateRequest> UpdateResidente(ResidenteUpdateRequest editResidente)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = @"UPDATE RESIDENTE SET
                      ID_PERSONA      = :Id_Persona,
                      ID_PROPIEDAD    = :Id_Propiedad,
                      TIPO_RESIDENTE  = :Tipo_Residente,
                      FECHA_INGRESO   = TO_DATE(:Fecha_Ingreso, 'YYYY-MM-DD'),
                      FECHA_SALIDA    = CASE WHEN :Fecha_Salida IS NULL THEN NULL
                                             ELSE TO_DATE(:Fecha_Salida, 'YYYY-MM-DD') END,
                      ACTIVO          = :Activo,
                      OBSERVACIONES   = :Observaciones
                      WHERE ID_RESIDENTE = :Id_Residente";
                await db.ExecuteAsync(query, editResidente);
                return editResidente;
            }
        }

        public async Task<bool> DeleteResidente(int id)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = "DELETE FROM RESIDENTE WHERE ID_RESIDENTE = :id";
                await db.ExecuteAsync(query, new { id });
                return true;
            }
        }
    }
}
