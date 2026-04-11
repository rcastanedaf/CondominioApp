using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class TipoPropiedadRepository : ITipoPropiedadRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public TipoPropiedadRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<List<Tipo_Propiedad>> GetAllAsync()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM Tipo_Propiedad";

                    var result = (await db.QueryAsync<Tipo_Propiedad>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Tipo_Propiedad>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Tipo_Propiedad>> GetId(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Tipo_Propiedad WHERE id_tipo_propiedad = {id}";

                    var result = (await db.QueryAsync<Tipo_Propiedad>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Tipo_Propiedad>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Tipo_Propiedad>> GetNombre(string nombre)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Tipo_Propiedad WHERE nombre = {nombre}";

                    var result = (await db.QueryAsync<Tipo_Propiedad>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Tipo_Propiedad>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TipoPropiedadCreateRequest> CreateTipoPropiedad(TipoPropiedadCreateRequest newTipoPropiedad)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO Tipo_Propiedad(nombre, descripcion) " +
                        $"VALUES ('{newTipoPropiedad.Nombre}', '{newTipoPropiedad.Descripcion}')";

                    var result = await db.ExecuteAsync(query);

                    return newTipoPropiedad;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TipoPropiedadUpdateRequest> UpdateTipoPropiedad(TipoPropiedadUpdateRequest editTipoPropiedad)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE Tipo_Propiedad SET nombre = '{editTipoPropiedad.Nombre}', " +
                        $"descripcion = '{editTipoPropiedad.Descripcion}' " +
                        $"WHERE id_persona = {editTipoPropiedad.Id_Tipo_Propiedad}";

                    var result = await db.ExecuteAsync(query);

                    return editTipoPropiedad;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTipoPropiedad(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"DELETE FROM Tipo_Propiedad WHERE id_tipo_propiedad = {id}";

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
