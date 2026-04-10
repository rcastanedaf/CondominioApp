using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ICuentaPorCobrarRepository
    {
        Task<List<CuentaPorCobrarModel>> GetAllAsync();
        Task<CuentaPorCobrarModel?> GetByIdAsync(int id);
        Task<List<CuentaPorCobrarModel>> GetByResidenteAsync(int idResidente);
        Task CreateAsync(CuentaPorCobrarModel model);
        Task UpdateAsync(CuentaPorCobrarModel model);
        Task DeleteAsync(int id);
    }
}
