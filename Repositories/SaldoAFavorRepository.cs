using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class SaldoAFavorRepository : ISaldoAFavorRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public SaldoAFavorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<List<SaldoAFavor>> GetAllAsync()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM Saldo_A_Favor";

                    var result = (await db.QueryAsync<SaldoAFavor>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<SaldoAFavor>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SaldoAFavor>> GetId(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Saldo_A_Favor WHERE id_saldo_a_favor = {id}";

                    var result = (await db.QueryAsync<SaldoAFavor>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<SaldoAFavor>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SaldoAFavor>> GetNombre(string nombre)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM Banco WHERE nombre = {nombre}";

                    var result = (await db.QueryAsync<SaldoAFavor>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<SaldoAFavor>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SaldoAFavorCreateRequest> CreateSaldoAFavor(SaldoAFavorCreateRequest newSaldoAFavor)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO Saldo_A_Favor(id_residente, id_pago_origen, monto_original, monto_disponible, motivo, estado, fecha_generacion," +
                        $" fecha_vencimiento, aplicado, fecha_aplicacion, generado, observaciones) " +
                        $"VALUES ('{newSaldoAFavor.Id_residente}', '{newSaldoAFavor.Id_Pago_Origen}', '{newSaldoAFavor.Monto_Original}', '{newSaldoAFavor.Monto_Disponible}', '{newSaldoAFavor.Motivo}', '{newSaldoAFavor.Estado}', '{newSaldoAFavor.Fecha_Generacion}', '{newSaldoAFavor.Fecha_Vencimiento}', '{newSaldoAFavor.Aplicado}', '{newSaldoAFavor.Fecha_Aplicacion}', '{newSaldoAFavor.Generado}', '{newSaldoAFavor.Observaciones}')";

                    var result = await db.ExecuteAsync(query);

                    return newSaldoAFavor;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SaldoAFavorUpdateRequest> UpdateSaldoAFavor(SaldoAFavorUpdateRequest editSaldoAFavor)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE Saldo_A_Favor SET id_residente = '{editSaldoAFavor.Id_residente}', " +
                        $"id_pago_origen = '{editSaldoAFavor.Id_Pago_Origen}' " +
                        $"monto_original = '{editSaldoAFavor.Monto_Original}' " +
                        $"monto_disponible = '{editSaldoAFavor.Monto_Disponible}' " +
                        $"motivo = '{editSaldoAFavor.Motivo}' " +
                        $"estado = '{editSaldoAFavor.Estado}' " +
                        $"fecha_generacion = '{editSaldoAFavor.Fecha_Generacion}' " +
                        $"fecha_vencimiento = '{editSaldoAFavor.Fecha_Vencimiento}' " +
                        $"aplicado = '{editSaldoAFavor.Aplicado}' " +
                        $"fecha_aplicacion = '{editSaldoAFavor.Fecha_Aplicacion}' " +
                        $"generado = '{editSaldoAFavor.Generado}' " +
                        $"observaciones = '{editSaldoAFavor.Observaciones}' " +
                        $"WHERE id_saldo = {editSaldoAFavor.Id_Saldo}";

                    var result = await db.ExecuteAsync(query);

                    return editSaldoAFavor;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteSaldoAFavor(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"DELETE FROM Saldo_A_Favor WHERE id_saldo = {id}";

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
