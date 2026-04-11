using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ItipoPropiedadService
    {
        Task<List<tipoPropiedadModel>> GetAll();
        Task<tipoPropiedadRequest> Create(tipoPropiedadRequest request);
        Task<tipoPropiedadModel> Update(tipoPropiedadModel request, int id);
        Task<bool> Delete(int id);
    }
}