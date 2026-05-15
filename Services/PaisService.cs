using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _repo;

        public PaisService(IPaisRepository repository)
        {
            _repo = repository;
        }

        public Task<List<PaisModel>> GetAll() => _repo.GetAll();
        public Task<PaisModel?> GetById(int id) => _repo.GetById(id);
        public Task<int> Create(PaisRequest request) => _repo.Create(request);
        public Task<int> Update(int id, PaisRequest req) => _repo.Update(id, req);
        public Task<bool> Delete(int id) => _repo.Delete(id);
    }
}