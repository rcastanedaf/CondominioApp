using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IFacturaService
    {
        Task<List<FacturaModel>> GetAllAsync();
        Task<FacturaModel?> GetByIdAsync(int id);
        Task<List<FacturaModel>> GetByPropiedadAsync(int idPropiedad);
        Task<int> GetNextCorrelativeAsync();
        Task<int> CreateAsync(FacturaModel model);
        Task UpdateAsync(FacturaModel model);
        Task DeleteAsync(int id);
    }
}
