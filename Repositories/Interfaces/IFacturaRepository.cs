using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IFacturaRepository
    {
        Task<List<FacturaModel>> GetAllAsync();
        Task<FacturaModel?> GetByIdAsync(int id);
        Task<List<FacturaModel>> GetByPropiedadAsync(int idPropiedad);
        Task CreateAsync(FacturaModel model);
        Task UpdateAsync(FacturaModel model);
        Task DeleteAsync(int id);
    }
}
