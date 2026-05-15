using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IPermisoRepository
    {
        Task<IEnumerable<PermisoModel>> GetAllAsync();
        Task<PermisoModel?> GetByIdAsync(int id);
    }
}