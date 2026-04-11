using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IPagoRepository
    {
        Task<List<PagoModel>> GetAllAsync();
        Task<PagoModel?> GetByIdAsync(int id);
        Task<List<PagoModel>> GetByFacturaAsync(int idFactura);
        Task CreateAsync(PagoModel model);
        Task UpdateAsync(PagoModel model);
        Task DeleteAsync(int id);
    }
}
