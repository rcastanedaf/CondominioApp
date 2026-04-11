using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ITipoServicioService
    {
        Task<List<TipoServicioModel>> GetAllAsync();
        Task<TipoServicioModel?> GetByIdAsync(int id);
        Task CreateAsync(TipoServicioModel model);
        Task UpdateAsync(TipoServicioModel model);
        Task DeleteAsync(int id);
    }
}