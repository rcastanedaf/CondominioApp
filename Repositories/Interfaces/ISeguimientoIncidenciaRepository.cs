using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ISeguimientoIncidenciaRepository
    {
        Task<List<SeguimientoIncidenciaModel>> GetAllAsync();
        Task<SeguimientoIncidenciaModel?> GetByIdAsync(int id);
        Task CreateAsync(SeguimientoIncidenciaModel model);
        Task UpdateAsync(SeguimientoIncidenciaModel model);
        Task DeleteAsync(int id);
        Task<List<SeguimientoIncidenciaModel>> GetByIncidenciaAsync(int id);
    }
}