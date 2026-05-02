using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IProveedorService
    {
        Task<List<ProveedorModel>> GetAllAsync();
        Task<ProveedorCreateRequest> Create(ProveedorCreateRequest req);
        Task<ProveedorUpdateRequest> Update(ProveedorUpdateRequest req);
        Task<bool> Delete(int id);
    }
}
