using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ICobroMoraService
    {
        Task<List<CobroMoraModel>> GetAllAsync();
        Task<CobroMoraModel?> GetByIdAsync(int id);
        Task CreateAsync(CobroMoraModel model);
        Task UpdateAsync(CobroMoraModel model);
        Task DeleteAsync(int id);
    }
}