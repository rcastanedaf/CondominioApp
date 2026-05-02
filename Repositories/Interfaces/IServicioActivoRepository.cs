using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IServicioActivoRepository
    {
        Task<List<ServicioActivoModel>> GetAllAsync();
        Task<List<ServicioActivoModel>> GetByPropiedad(int idPropiedad);
        Task<List<ServicioActivoModel>> GetByResidente(int idResidente);
        Task<ServicioActivoCreateRequest> Create(ServicioActivoCreateRequest req);
        Task<ServicioActivoUpdateRequest> Update(ServicioActivoUpdateRequest req);
        Task<bool> Delete(int id);
    }
}
