using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IPagoService
    {
        Task<List<PagoModel>> GetAllAsync();
        Task<PagoModel?> GetByIdAsync(int id);
        Task<List<PagoModel>> GetByFacturaAsync(int idFactura);
        Task CreateAsync(PagoModel model);
        Task UpdateAsync(PagoModel model);
        Task DeleteAsync(int id);
        Task<List<PagoModel>> GetByResidenteAsync(int idResidente);

    }
}
