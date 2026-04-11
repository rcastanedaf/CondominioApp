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
                    var query = $"SELECT * FROM Multa WHERE id_multa = {id}";

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

        public async Task<List<Multa>> GetNombre(string nombre)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Multa WHERE nombre = {nombre}";

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

        public async Task<MultaCreateRequest> CreateMulta(MultaCreateRequest newMulta)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO Multa(id_residente, id_propiedad, id_tipo_infraccion, descripcion, monto, fecha_infraccion, fecha_vencimiento," +
                        $" estado, evidencia, id_factura, id_apelacion, id_emitida, id_aprovada, observaciones, fecha_registro) " +
                        $"VALUES ('{newMulta.Id_Residente}', '{newMulta.Id_Propiedad}', '{newMulta.Id_Tipo_Infraccion}', '{newMulta.Descripcion}', '{newMulta.Monto}', '{newMulta.Fecha_Infraccion}', " +
                        $"'{newMulta.Fecha_Vencimiento}', '{newMulta.Estado}', '{newMulta.Evidencia}', '{newMulta.Id_Factura}', '{newMulta.Id_Apelacion}', " +
                        $"'{newMulta.Id_Emitida}', '{newMulta.Id_Aprobada}', '{newMulta.Observaciones}', '{newMulta.Fecha_Registro}')";

                    var result = await db.ExecuteAsync(query);

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
                    var query = $"UPDATE Multa SET id_residente = '{editMulta.Id_Residente}', " +
                        $"id_propiedad = '{editMulta.Id_Propiedad}' " +
                        $"id_tipo_infraccion = '{editMulta.Id_Tipo_Infraccion}' " +
                        $"descripcion = '{editMulta.Descripcion}' " +
                        $"monto = '{editMulta.Monto}' " +
                        $"fecha_infraccion = '{editMulta.Fecha_Infraccion}' " +
                        $"fecha_vencimiento = '{editMulta.Fecha_Vencimiento}' " +
                        $"estado = '{editMulta.Estado}' " +
                        $"evidencia = '{editMulta.Evidencia}' " +
                        $"id_factura = '{editMulta.Id_Factura}' " +
                        $"id_apelacion = '{editMulta.Id_Apelacion}' " +
                        $"id_emitida = '{editMulta.Id_Emitida}' " +
                        $"id_aprovada = '{editMulta.Id_Aprobada}' " +
                        $"observaciones = '{editMulta.Observaciones}' " +
                        $"fecha_registro = '{editMulta.Fecha_Registro}' " +
                        $"WHERE id_persona = {editMulta.Id_Multa}";

                    var result = await db.ExecuteAsync(query);

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
                    var query = $"DELETE FROM Multa WHERE id_multa = {id}";

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
