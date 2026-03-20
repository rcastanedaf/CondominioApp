using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IConceptoDescuentoRepository
    {
        public Task<List<Concepto_Descuento>> GetAllAsync();
        public Task<List<Concepto_Descuento>> GetId(int id);
        public Task<List<Concepto_Descuento>> GetNombre(string nombre);
        public Task<ConceptoDescuentoCreateRequest> CreateConceptoDescuento(ConceptoDescuentoCreateRequest newConceptoDescuento);
        public Task<ConceptoDescuentoUpdateRequest> UpdateConceptoDescuento(ConceptoDescuentoUpdateRequest editConceptoDescuento);
        public Task<bool> DeleteConceptoDescuento(int id);
    }
}
