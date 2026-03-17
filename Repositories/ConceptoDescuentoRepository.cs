using Condominio.Models;

namespace Condominio.Repositories
{
    public class ConceptoDescuentoRepository
    {
        public async Task<List<Concepto_Descuento>> GetAllAsync()
        {
            var list = new List<Concepto_Descuento>
            {
                new Concepto_Descuento { Id = 1, Nombre = "Test 1", Tipo = "Guatemala", Valor = 1, Autorizacion = 1},
                new Concepto_Descuento { Id = 2, Nombre = "Test 2", Tipo = "Guatemala", Valor = 1, Autorizacion = 1},
                new Concepto_Descuento { Id = 3, Nombre = "Test 3", Tipo = "Guatemala", Valor = 1, Autorizacion = 1}
            };
            return list;
        }

        public async Task<List<Concepto_Descuento>> GetId(int id)
        {
            var list = new List<Concepto_Descuento>
            {
                new Concepto_Descuento { Id = 3, Nombre = "Test 3", Tipo = "Guatemala", Valor = 1, Autorizacion = 1}
            };
            return list;
        }

        public async Task<List<Concepto_Descuento>> GetNombre(string nombre)
        {
            var list = new List<Concepto_Descuento>
            {
                 new Concepto_Descuento { Id = 3, Nombre = "Test 3", Tipo = "Guatemala", Valor = 1, Autorizacion = 1}
            };
            return list;
        }

        public async Task<List<Concepto_Descuento>> CreateConceptoDescuento(Concepto_Descuento newConceptoDescuento)
        {
            var list = new List<Concepto_Descuento>
            {
                 new Concepto_Descuento { Id = 3, Nombre = "Test 3", Tipo = "Guatemala", Valor = 1, Autorizacion = 1}
            };
            return list;
        }

        public async Task<List<Concepto_Descuento>> UpdateConceptoDescuento(Concepto_Descuento editConceptoDescuento)
        {
            var list = new List<Concepto_Descuento>
            {
                 new Concepto_Descuento { Id = 3, Nombre = "Test 3", Tipo = "Guatemala", Valor = 1, Autorizacion = 1}
            };
            return list;
        }

        public async Task<List<Concepto_Descuento>> DeleteConceptoDescuento(int id)
        {
            var list = new List<Concepto_Descuento>
            {
                 new Concepto_Descuento { Id = 3, Nombre = "Test 3", Tipo = "Guatemala", Valor = 1, Autorizacion = 1}
            };
            return list;
        }
    }
}
