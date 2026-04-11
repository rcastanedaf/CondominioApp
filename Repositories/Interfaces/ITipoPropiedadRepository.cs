using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ItipoPropiedadRepository
    {
        Task<List<tipoPropiedadModel>> GetAll();
        Task<tipoPropiedadRequest> Create(tipoPropiedadRequest request);
        Task<tipoPropiedadModel> Update(tipoPropiedadModel request, int id);
        Task<bool> Delete(int id);
    }
}
