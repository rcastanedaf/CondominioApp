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
                    var query = "SELECT * FROM Residente";

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
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO Residente(id_persona, id_propiedad, tipo_residente, fecha_ingreso, fecha_salida, estado, observaciones) " +
                        $"VALUES ('{newResidente.Id_Persona}', '{newResidente.Id_Propiedad}', '{newResidente.Tipo_Residente}', '{newResidente.Fecha_Ingreso}', '{newResidente.Fecha_Salida}', '{newResidente.Estado}', '{newResidente.Observaciones}')";

                    var result = await db.ExecuteAsync(query);

                    return newResidente;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResidenteUpdateRequest> UpdateResidente(ResidenteUpdateRequest editResidente)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE Residente SET id_persona = '{editResidente.Id_Persona}', " +
                        $"id_propiedad = '{editResidente.Id_Propiedad}' " +
                        $"tipo_residente = '{editResidente.Tipo_Residente}' " +
                        $"fecha_ingreso = '{editResidente.Fecha_Ingreso}' " +
                        $"fecha_salida = '{editResidente.Fecha_Salida}' " +
                        $"estado = '{editResidente.Estado}' " +
                        $"observaciones = '{editResidente.Observaciones}' " +
                        $"WHERE id_persona = {editResidente.Id_Residente}";

                    var result = await db.ExecuteAsync(query);

                    return editResidente;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteResidente(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"DELETE FROM Residente WHERE id_persona = {id}";

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
