using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _repo;
        public VehiculoService(IVehiculoRepository repo) => _repo = repo;

        public Task<List<VehiculoModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<List<VehiculoModel>> GetByResidente(int id) => _repo.GetByResidente(id);
        public Task<VehiculoCreateRequest> Create(VehiculoCreateRequest r) => _repo.Create(r);
        public Task<VehiculoUpdateRequest> Update(VehiculoUpdateRequest r) => _repo.Update(r);
        public Task<bool> Delete(int id) => _repo.Delete(id);

    }
}
