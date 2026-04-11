using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ISeguimientoIncidenciaService
    {
        Task<List<SeguimientoIncidenciaModel>> GetAllAsync();
        Task<SeguimientoIncidenciaModel?> GetByIdAsync(int id);
        Task CreateAsync(SeguimientoIncidenciaModel model);
        Task UpdateAsync(SeguimientoIncidenciaModel model);
        Task DeleteAsync(int id);
    }
}