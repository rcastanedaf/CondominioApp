using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public PersonaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<List<Persona>> GetAllAsync()
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = @"SELECT
                        ID_PERSONA          Id_Persona,
                        TIPO                Tipo,
                        NOMBRES             Nombres,
                        APELLIDOS           Apellidos,
                        DPI                 Dpi,
                        PASAPORTE           Pasaporte,
                        FECHA_NACIMIENTO    Fecha_Nacimiento,
                        ID_ESTADO_CIVIL     Id_Estado_Civil,
                        ID_NACIONALIDAD     Nacionalidad,
                        TELEFONO_PRINCIPAL  Telefono_Principal,
                        TELEFONO_SECUNDARIO Telefono_Secundario,
                        EMAIL               Email,
                        NIT                 Nit,
                        ID_REGIMEN_FISCAL   Id_Regimen_Fiscal,
                        OBSERVACIONES       Observaciones,
                        ACTIVO              Activo,
                        FECHA_REGISTRO      Fecha_Registro
                      FROM PERSONA";

                return (await db.QueryAsync<Persona>(query)).ToList();
            }
        }

        public async Task<List<Persona>> GetId(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Persona WHERE id_persona = {id}";

                    var result = (await db.QueryAsync<Persona>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Persona>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Persona>> GetNombre(string nombre)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Persona WHERE nombre = {nombre}";

                    var result = (await db.QueryAsync<Persona>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Persona>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonaCreateRequest> CreatePersona(PersonaCreateRequest newPersona)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = @"INSERT INTO PERSONA
                            (TIPO, NOMBRES, APELLIDOS, DPI, PASAPORTE, FECHA_NACIMIENTO,
                            ID_ESTADO_CIVIL, ID_NACIONALIDAD, TELEFONO_PRINCIPAL, TELEFONO_SECUNDARIO,
                            EMAIL, NIT, ID_REGIMEN_FISCAL, OBSERVACIONES, ACTIVO, FECHA_REGISTRO)
                            VALUES
                            (:Tipo, :Nombres, :Apellidos, :DPI, :Pasaporte,
                            TO_DATE(:Fecha_Nacimiento, 'YYYY-MM-DD'),
                            :Id_Estado_Civil, :Nacionalidad, :Telefono_Principal, :Telefono_Secundario,
                            :Email, :NIT, :Id_Regimen_Fiscal, :Observaciones, :Activo,
                            TO_DATE(:Fecha_Registro, 'YYYY-MM-DD'))";

                await db.ExecuteAsync(query, newPersona);
                return newPersona;
            }
        }

        public async Task<PersonaUpdateRequest> UpdatePersona(PersonaUpdateRequest editPersona)
        {
            using (IDbConnection db = new OracleConnection(_stringConnection))
            {
                var query = @"UPDATE PERSONA SET
                              TIPO                = :Tipo,
                              NOMBRES             = :Nombres,
                              APELLIDOS           = :Apellidos,
                              DPI                 = :DPI,
                              PASAPORTE           = :Pasaporte,
                              FECHA_NACIMIENTO    = TO_DATE(:Fecha_Nacimiento, 'YYYY-MM-DD'),
                              ID_ESTADO_CIVIL     = :Id_Estado_Civil,
                              ID_NACIONALIDAD     = :Nacionalidad,
                              TELEFONO_PRINCIPAL  = :Telefono_Principal,
                              TELEFONO_SECUNDARIO = :Telefono_Secundario,
                              EMAIL               = :Email,
                              NIT                 = :NIT,
                              ID_REGIMEN_FISCAL   = :Id_Regimen_Fiscal,
                              OBSERVACIONES       = :Observaciones,
                              ACTIVO              = :Activo,
                              FECHA_REGISTRO      = TO_DATE(:Fecha_Registro, 'YYYY-MM-DD')
                              WHERE ID_PERSONA    = :Id_Persona";

                await db.ExecuteAsync(query, editPersona);
                return editPersona;
            }
        }

        public async Task<bool> DeletePersona(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"DELETE FROM Persona WHERE id_persona = {id}";

                    var result = await db.ExecuteAsync(query);

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
