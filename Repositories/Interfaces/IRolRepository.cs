using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<RolModel>> GetAllAsync();
        Task<RolModel?> GetByIdAsync(int id);
        Task<int> CreateAsync(RolCreateRequest request);
        Task<int> UpdateAsync(int id, RolCreateRequest request);
        Task<int> ToggleActivoAsync(int id, int activo);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<PermisoModel>> GetPermisosAsync(int idRol);
        Task<int> AsignarPermisoAsync(int idRol, int idPermiso);
        Task<int> QuitarPermisoAsync(int idRol, int idPermiso);
    }
}