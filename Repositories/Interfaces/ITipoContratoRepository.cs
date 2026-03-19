using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ITipoContratoRepository
    {
        Task<List<TipoContratoModel>> GetAllAsync();

        Task<TipoContratoModel?> GetByIdAsync(int id);

        Task<TipoContratoModel> CreateAsync(TipoContratoModel model);

        Task<bool> UpdateAsync(TipoContratoModel model);

        Task<bool> DeleteAsync(int id);
    }
}