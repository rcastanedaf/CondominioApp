using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _repo;
        public ProveedorService(IProveedorRepository repo) => _repo = repo;
        public Task<List<ProveedorModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<ProveedorCreateRequest> Create(ProveedorCreateRequest req) => _repo.Create(req);
        public Task<ProveedorUpdateRequest> Update(ProveedorUpdateRequest req) => _repo.Update(req);
        public Task<bool> Delete(int id) => _repo.Delete(id);
    }
}
