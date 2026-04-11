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
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM Persona";

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
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO Persona(tipo, nombres, apellidos, dpi, pasaporte, fecha_nacimiento, id_estado_civil," +
                        $" id_nacionalidad, telefono_principal, telefono_secundario, email, nit, id_regimen_fiscal, observaciones, estado, fecha_registro) " +
                        $"VALUES ('{newPersona.Tipo}', '{newPersona.Nombres}', '{newPersona.Apellidos}', '{newPersona.DPI}', '{newPersona.Pasaporte}', '{newPersona.Fecha_Nacimiento}', " +
                        $"'{newPersona.Id_Estado_Civil}', '{newPersona.Nacionalidad}', '{newPersona.Telefono_Principal}', '{newPersona.Telefono_Secundario}', '{newPersona.Email}', " +
                        $"'{newPersona.NIT}', '{newPersona.Id_Regimen_Fiscal}', '{newPersona.Observaciones}', '{newPersona.Estado}', '{newPersona.Fecha_Registro}')";

                    var result = await db.ExecuteAsync(query);

                    return newPersona;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonaUpdateRequest> UpdatePersona(PersonaUpdateRequest editPersona)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE Persona SET tipo = '{editPersona.Tipo}', " +
                        $"nombres = '{editPersona.Nombres}' " +
                        $"apellidos = '{editPersona.Apellidos}' " +
                        $"dpi = '{editPersona.DPI}' " +
                        $"pasaporte = '{editPersona.Pasaporte}' " +
                        $"fecha_nacimiento = '{editPersona.Fecha_Nacimiento}' " +
                        $"id_estado_civil = '{editPersona.Id_Estado_Civil}' " +
                        $"id_nacionalidad = '{editPersona.Nacionalidad}' " +
                        $"telefono_principal = '{editPersona.Telefono_Principal}' " +
                        $"telefono_secundario = '{editPersona.Telefono_Secundario}' " +
                        $"email = '{editPersona.Email}' " +
                        $"nit = '{editPersona.NIT}' " +
                        $"id_regimen_fiscal = '{editPersona.Id_Regimen_Fiscal}' " +
                        $"observaciones = '{editPersona.Observaciones}' " +
                        $"estado = '{editPersona.Estado}' " +
                        $"fecha_registro = '{editPersona.Fecha_Registro}' " +
                        $"WHERE id_persona = {editPersona.Id_Persona}";

                    var result = await db.ExecuteAsync(query);

                    return editPersona;
                }
            }
            catch (Exception)
            {
                throw;
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
