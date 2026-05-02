using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class VisitaAutorizadaService : IVisitaAutorizadaService
    {
        private readonly IVisitaAutorizadaRepository _repo;
        public VisitaAutorizadaService(IVisitaAutorizadaRepository repo) => _repo = repo;

        public Task<List<VisitaAutorizadaModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<List<VisitaAutorizadaModel>> GetActivas() => _repo.GetActivas();
        public Task<VisitaAutorizadaCreateRequest> Create(VisitaAutorizadaCreateRequest r) => _repo.Create(r);
        public Task<VisitaAutorizadaUpdateRequest> Update(VisitaAutorizadaUpdateRequest r) => _repo.Update(r);
        public Task<bool> CambiarEstado(int id, string estado) => _repo.CambiarEstado(id, estado);

    }
}
