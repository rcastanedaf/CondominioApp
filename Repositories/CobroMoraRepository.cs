using System.Data;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Repositories
{
    public class CobroMoraRepository : ICobroMoraRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public CobroMoraRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<List<CobroMoraModel>> GetAllAsync()
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                        ID_MORA IdMora,
                        ID_CUENTA IdCuenta,
                        FECHA_CALCULO FechaCalculo,
                        DIAS_ATRASO DiasAtraso,
                        SALDO_BASE SaldoBase,
                        PORCENTAJE_APLICADO PorcentajeAplicado,
                        MONTO_MORA MontoMora,
                        ACUMULADO_TOTAL AcumuladoTotal,
                        OBSERVACIONES Observaciones
                        FROM COBRO_MORA";

            return (await db.QueryAsync<CobroMoraModel>(query)).ToList();
        }

        public async Task<CobroMoraModel?> GetByIdAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"SELECT 
                        ID_MORA IdMora,
                        ID_CUENTA IdCuenta,
                        FECHA_CALCULO FechaCalculo,
                        DIAS_ATRASO DiasAtraso,
                        SALDO_BASE SaldoBase,
                        PORCENTAJE_APLICADO PorcentajeAplicado,
                        MONTO_MORA MontoMora,
                        ACUMULADO_TOTAL AcumuladoTotal,
                        OBSERVACIONES Observaciones
                        FROM COBRO_MORA
                        WHERE ID_MORA = :id";

            return await db.QueryFirstOrDefaultAsync<CobroMoraModel>(query, new { id });
        }

        public async Task CreateAsync(CobroMoraModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"INSERT INTO COBRO_MORA
                        (ID_CUENTA, FECHA_CALCULO, DIAS_ATRASO, SALDO_BASE,
                         PORCENTAJE_APLICADO, MONTO_MORA, ACUMULADO_TOTAL, OBSERVACIONES)
                        VALUES
                        (:IdCuenta, :FechaCalculo, :DiasAtraso, :SaldoBase,
                         :PorcentajeAplicado, :MontoMora, :AcumuladoTotal, :Observaciones)";

            await db.ExecuteAsync(query, model);
        }

        public async Task UpdateAsync(CobroMoraModel model)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = @"UPDATE COBRO_MORA SET
                        ID_CUENTA = :IdCuenta,
                        FECHA_CALCULO = :FechaCalculo,
                        DIAS_ATRASO = :DiasAtraso,
                        SALDO_BASE = :SaldoBase,
                        PORCENTAJE_APLICADO = :PorcentajeAplicado,
                        MONTO_MORA = :MontoMora,
                        ACUMULADO_TOTAL = :AcumuladoTotal,
                        OBSERVACIONES = :Observaciones
                        WHERE ID_MORA = :IdMora";

            int affected = await db.ExecuteAsync(query, model);
            if (affected == 0)
                throw new Exception($"No se encontró el cobro con ID_MORA = {model.IdMora}. Verifica que el ID sea correcto.");
        }

        public async Task DeleteAsync(int id)
        {
            using IDbConnection db = new OracleConnection(_stringConnection);

            var query = "DELETE FROM COBRO_MORA WHERE ID_MORA = :id";

            await db.ExecuteAsync(query, new { id });
        }
    }
}