using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ICobroMoraRepository
    {
        Task<List<CobroMoraModel>> GetAllAsync();
        Task<CobroMoraModel?> GetByIdAsync(int id);
        Task CreateAsync(CobroMoraModel model);
        Task UpdateAsync(CobroMoraModel model);
        Task DeleteAsync(int id);
    }
}