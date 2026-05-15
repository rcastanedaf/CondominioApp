using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _repo;

        public RegionService(IRegionRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<RegionModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<IEnumerable<RegionModel>> GetByPaisAsync(int idPais) => _repo.GetByPaisAsync(idPais);
        public Task<RegionModel?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<int> CreateAsync(RegionModel model) => _repo.CreateAsync(model);
        public Task<int> UpdateAsync(RegionModel model) => _repo.UpdateAsync(model);
        public Task<int> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}