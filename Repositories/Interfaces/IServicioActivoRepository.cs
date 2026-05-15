using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IServicioActivoRepository
    {
        Task<IEnumerable<ServicioActivoModel>> GetAllAsync();
        Task<IEnumerable<ServicioActivoModel>> GetByPropiedadAsync(int idPropiedad);
        Task<ServicioActivoModel?> GetByIdAsync(int id);
        Task<int> CreateAsync(ServicioActivoCreateRequest request);
        Task<int> UpdateAsync(int id, ServicioActivoUpdateRequest request);
        Task<int> DeleteAsync(int id);
    }
}