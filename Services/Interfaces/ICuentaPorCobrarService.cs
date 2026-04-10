using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ICuentaPorCobrarService
    {
        Task<List<CuentaPorCobrarModel>> GetAllAsync();
        Task<CuentaPorCobrarModel?> GetByIdAsync(int id);
        Task<List<CuentaPorCobrarModel>> GetByResidenteAsync(int idResidente);
        Task CreateAsync(CuentaPorCobrarModel model);
        Task UpdateAsync(CuentaPorCobrarModel model);
        Task DeleteAsync(int id);
    }
}
