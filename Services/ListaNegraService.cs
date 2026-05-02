using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class ListaNegraService : IListaNegraService
    {
        private readonly IListaNegraRepository _repo;
        public ListaNegraService(IListaNegraRepository repo) => _repo = repo;

        public Task<List<ListaNegraModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<ListaNegraCreateRequest> Create(ListaNegraCreateRequest r) => _repo.Create(r);
        public Task<ListaNegraUpdateRequest> Update(ListaNegraUpdateRequest r) => _repo.Update(r);
        public Task<bool> Desactivar(int id) => _repo.Desactivar(id);

    }
}
