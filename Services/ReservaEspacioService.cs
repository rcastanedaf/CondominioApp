using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class ReservaEspacioService : IReservaEspacioService
    {
        private readonly IReservaEspacioRepository _repo;
        public ReservaEspacioService(IReservaEspacioRepository repo) => _repo = repo;
        public Task<List<ReservaEspacioModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<List<ReservaEspacioModel>> GetByEspacio(int id) => _repo.GetByEspacio(id);
        public Task<List<ReservaEspacioModel>> GetByResidente(int id) => _repo.GetByResidente(id);
        public Task<ReservaEspacioCreateRequest> Create(ReservaEspacioCreateRequest r) => _repo.Create(r);
        public Task<ReservaEspacioUpdateRequest> Update(ReservaEspacioUpdateRequest r) => _repo.Update(r);
        public Task<bool> CambiarEstado(int id, string estado, int? aprobadoPor) => _repo.CambiarEstado(id, estado, aprobadoPor);

    }
}
