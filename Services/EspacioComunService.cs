using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class EspacioComunService : IEspacioComunService
    {
        private readonly IEspacioComunRepository _repo;
        public EspacioComunService(IEspacioComunRepository repo) => _repo = repo;
        public Task<List<EspacioComunModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<EspacioComunCreateRequest> Create(EspacioComunCreateRequest r) => _repo.Create(r);
        public Task<EspacioComunUpdateRequest> Update(EspacioComunUpdateRequest r) => _repo.Update(r);
        public Task<bool> CambiarEstado(int id, string estado) => _repo.CambiarEstado(id, estado);
        public Task<bool> Delete(int id) => _repo.Delete(id);

    }
}
