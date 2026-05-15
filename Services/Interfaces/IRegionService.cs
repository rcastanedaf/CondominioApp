using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionModel>> GetAllAsync();
        Task<IEnumerable<RegionModel>> GetByPaisAsync(int idPais);
        Task<RegionModel?> GetByIdAsync(int id);
        Task<int> CreateAsync(RegionModel model);
        Task<int> UpdateAsync(RegionModel model);
        Task<int> DeleteAsync(int id);
    }
}