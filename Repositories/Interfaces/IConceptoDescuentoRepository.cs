using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IConceptoDescuentoRepository
    {
        public Task<List<Concepto_Descuento>> GetAllAsync();
        public Task<List<Concepto_Descuento>> GetId(int id);
        public Task<List<Concepto_Descuento>> GetNombre(string nombre);
        public Task<List<Concepto_Descuento>> CreateConceptoDescuento(Concepto_Descuento newConceptoDescuento);
        public Task<List<Concepto_Descuento>> UpdatetConceptoDescuento(Concepto_Descuento editConceptoDescuento);
        public Task<List<Concepto_Descuento>> DeleteConceptoDescuento(int id);
    }
}
