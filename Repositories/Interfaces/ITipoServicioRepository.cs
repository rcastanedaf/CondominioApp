using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ITipoServicioRepository
    {
        Task<List<TipoServicioModel>> GetAllAsync();
        Task<TipoServicioModel?> GetByIdAsync(int id);
        Task CreateAsync(TipoServicioModel model);
        Task UpdateAsync(TipoServicioModel model);
        Task DeleteAsync(int id);
    }
}