using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IVehiculoService
    {
        Task<List<VehiculoModel>> GetAllAsync();
        Task<List<VehiculoModel>> GetByResidente(int idResidente);
        Task<VehiculoCreateRequest> Create(VehiculoCreateRequest req);
        Task<VehiculoUpdateRequest> Update(VehiculoUpdateRequest req);
        Task<bool> Delete(int id);

    }
}
