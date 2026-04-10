using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Condominio.Repositories
{
    public class ConceptoDescuentoRepository: IConceptoDescuentoRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _stringConnection;

        public ConceptoDescuentoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _stringConnection = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<List<Concepto_Descuento>> GetAllAsync()
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = "SELECT * FROM ConceptoDescuento";

                    var result = (await db.QueryAsync<Concepto_Descuento>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Concepto_Descuento>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Concepto_Descuento>> GetId(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM ConceptoDescuento WHERE id = {id}";

                    var result = (await db.QueryAsync<Concepto_Descuento>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Concepto_Descuento>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Concepto_Descuento>> GetNombre(string nombre)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"SELECT * FROM ConceptoDescuento WHERE nombre = {nombre}";

                    var result = (await db.QueryAsync<Concepto_Descuento>(query)).ToList();

                    if (result.Count > 0)
                    {
                        return result;
                    }

                    return new List<Concepto_Descuento>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ConceptoDescuentoCreateRequest> CreateConceptoDescuento(ConceptoDescuentoCreateRequest newConceptoDescuento)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"INSERT INTO ConceptoDescuento(nombre, tipo, valor, autorizacion) " +
                        $"VALUES ('{newConceptoDescuento.Nombre}', '{newConceptoDescuento.Tipo}', '{newConceptoDescuento.Valor}', '{newConceptoDescuento.Autorizacion}')";

                    var result = await db.ExecuteAsync(query);

                    return newConceptoDescuento;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ConceptoDescuentoUpdateRequest> UpdateConceptoDescuento(ConceptoDescuentoUpdateRequest editConceptoDescuento)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"UPDATE Banco SET nombre = '{editConceptoDescuento.Nombre}', tipo = '{editConceptoDescuento.Tipo}' , valor = '{editConceptoDescuento.Valor}' , autorizacion = '{editConceptoDescuento.Autorizacion}' WHERE id = {editConceptoDescuento.Id}";

                    var result = await db.ExecuteAsync(query);

                    return editConceptoDescuento;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteConceptoDescuento(int id)
        {
            try
            {
                using (IDbConnection db = new OracleConnection(_stringConnection))
                {
                    var query = $"DELETE FROM ConceptoDescuento WHERE id = {id}";

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
