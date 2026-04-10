using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IDetalleFacturaRepository
    {
        Task<List<DetalleFacturaModel>> GetAllAsync();
        Task<DetalleFacturaModel?> GetByIdAsync(int id);
        Task<List<DetalleFacturaModel>> GetByFacturaAsync(int idFactura);
        Task CreateAsync(DetalleFacturaModel model);
        Task UpdateAsync(DetalleFacturaModel model);
        Task DeleteAsync(int id);
    }
}
