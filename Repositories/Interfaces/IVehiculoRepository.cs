using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<List<VehiculoModel>> GetAllAsync();
        Task<List<VehiculoModel>> GetByResidente(int idResidente);
        Task<VehiculoModel> GetById(int id);
        Task<VehiculoCreateRequest> Create(VehiculoCreateRequest req);
        Task<VehiculoUpdateRequest> Update(VehiculoUpdateRequest req);
        Task<bool> Delete(int id);

    }
}
