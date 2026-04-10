using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class contratoService : IcontratoService
    {
        private readonly IcontratoRepository _repository;

        public contratoService(IcontratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<contratoModel>> GetAll() =>
            await _repository.GetAll();

        public async Task<contratoRequest> Create(contratoRequest request) =>
            await _repository.Create(request);

        public async Task<contratoModel> Update(contratoModel request, int id) =>
            await _repository.Update(request, id);

        public async Task<bool> Delete(int id) =>
            await _repository.Delete(id);
    }
}