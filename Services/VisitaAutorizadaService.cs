using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class VisitaAutorizadaService : IVisitaAutorizadaService
    {
        private readonly IVisitaAutorizadaRepository _repo;

        public VisitaAutorizadaService(IVisitaAutorizadaRepository repo)
        {
            _repo = repo;
        }

        public Task<List<VisitaAutorizadaModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<List<VisitaAutorizadaModel>> GetActivas() => _repo.GetActivas();
        public Task<VisitaAutorizadaModel?> GetById(int id) => _repo.GetById(id);
        public Task<int> Create(VisitaAutorizadaCreateRequest req) => _repo.Create(req);
        public Task<int> Update(int id, VisitaAutorizadaUpdateRequest req) => _repo.Update(id, req);
        public Task<bool> CambiarEstado(int id, string estado) => _repo.CambiarEstado(id, estado);
        public Task<bool> Delete(int id) => _repo.Delete(id);
    }
}