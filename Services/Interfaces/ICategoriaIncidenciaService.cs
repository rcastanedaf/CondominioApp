using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ICategoriaIncidenciaService
    {
        Task<List<CategoriaIncidenciaModel>> GetAllAsync();
        Task<CategoriaIncidenciaModel?> GetByIdAsync(int id);
        Task CreateAsync(CategoriaIncidenciaModel model);
        Task UpdateAsync(CategoriaIncidenciaModel model);
        Task DeleteAsync(int id);
    }
}