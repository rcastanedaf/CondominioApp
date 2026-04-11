using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IIncidenciaService
    {
        Task<List<IncidenciaModel>> GetAllAsync();
        Task<IncidenciaModel?> GetByIdAsync(int id);
        Task CreateAsync(IncidenciaModel model);
        Task UpdateAsync(IncidenciaModel model);
        Task DeleteAsync(int id);
    }
}