using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<List<EmpleadoModel>> GetAllAsync();
        Task<EmpleadoCreateRequest> Create(EmpleadoCreateRequest req);
        Task<EmpleadoUpdateRequest> Update(EmpleadoUpdateRequest req);
        Task<bool> Delete(int id);
    }
}
