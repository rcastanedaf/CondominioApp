using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoModel>> GetAllAsync();
        Task<EmpleadoCreateRequest> Create(EmpleadoCreateRequest req);
        Task<EmpleadoUpdateRequest> Update(EmpleadoUpdateRequest req);
        Task<bool> Delete(int id);
    }
}
