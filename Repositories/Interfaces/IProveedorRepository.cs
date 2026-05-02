using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IProveedorRepository
    {
        Task<List<ProveedorModel>> GetAllAsync();
        Task<ProveedorCreateRequest> Create(ProveedorCreateRequest req);
        Task<ProveedorUpdateRequest> Update(ProveedorUpdateRequest req);
        Task<bool> Delete(int id);
    }
}
