using Condominio.DTOs.Response;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IConceptoDescuentoService
    {
        public Task<ApiResponse<List<Concepto_Descuento>>> GetAllAsync();
        public Task<ApiResponse<List<Concepto_Descuento>>> GetId(int id);
        public Task<ApiResponse<List<Concepto_Descuento>>> GetNombre(string nombre);
        public Task<ApiResponse<List<Concepto_Descuento>>> CreateConceptoDescuento(Concepto_Descuento newConceptoDesc);
        public Task<ApiResponse<List<Concepto_Descuento>>> UpdateConceptoDescuento(Concepto_Descuento editConceptoDesc);
        public Task<ApiResponse<List<Concepto_Descuento>>> DeleteConceptoDescuento(int id);
    }
}
