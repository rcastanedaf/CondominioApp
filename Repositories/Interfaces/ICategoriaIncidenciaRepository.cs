using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ICategoriaIncidenciaRepository
    {
        Task<List<CategoriaIncidenciaModel>> GetAllAsync();
        Task<CategoriaIncidenciaModel?> GetByIdAsync(int id);
        Task CreateAsync(CategoriaIncidenciaModel model);
        Task UpdateAsync(CategoriaIncidenciaModel model);
        Task DeleteAsync(int id);
    }
}