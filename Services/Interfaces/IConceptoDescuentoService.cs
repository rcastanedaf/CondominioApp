using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IConceptoDescuentoService
    {
        public Task<List<Concepto_Descuento>> GetAllAsync();
        public Task<List<Concepto_Descuento>> GetId(int id);
        public Task<List<Concepto_Descuento>> GetNombre(string nombre);
        public Task<ConceptoDescuentoCreateRequest> CreateConceptoDescuento(ConceptoDescuentoCreateRequest newConceptoDesc);
        public Task<ConceptoDescuentoUpdateRequest> UpdateConceptoDescuento(ConceptoDescuentoUpdateRequest editConceptoDesc);
        public Task<bool> DeleteConceptoDescuento(int id);
    }
}
