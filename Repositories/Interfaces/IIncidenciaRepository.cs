using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IIncidenciaRepository
    {
        Task<List<IncidenciaModel>> GetAllAsync();
        Task<IncidenciaModel?> GetByIdAsync(int id);
        Task CreateAsync(IncidenciaModel model);
        Task UpdateAsync(IncidenciaModel model);
        Task DeleteAsync(int id);
    }
}