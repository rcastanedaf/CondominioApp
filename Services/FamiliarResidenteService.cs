using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class FamiliarResidenteService : IFamiliarResidenteService
    {
        private readonly IFamiliarResidenteRepository _repo;

        public FamiliarResidenteService(IFamiliarResidenteRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<FamiliarResidenteModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<IEnumerable<FamiliarResidenteModel>> GetByResidenteAsync(int idResidente) => _repo.GetByResidenteAsync(idResidente);
        public Task<FamiliarResidenteModel?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<int> CreateAsync(FamiliarResidenteCreateRequest request) => _repo.CreateAsync(request);
        public Task<int> UpdateAsync(int id, FamiliarResidenteUpdateRequest request) => _repo.UpdateAsync(id, request);
        public Task<int> DeleteAsync(int id) => _repo.DeleteAsync(id);
        public Task<int> ToggleActivoAsync(int id, int activo) => _repo.ToggleActivoAsync(id, activo);
    }
}