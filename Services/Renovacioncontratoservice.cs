using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class renovacionContratoService : IrenovacionContratoService
    {
        private readonly IrenovacionContratoRepository _repository;

        public renovacionContratoService(IrenovacionContratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<renovacionContratoModel>> GetAll() =>
            await _repository.GetAll();

        public async Task<renovacionContratoRequest> Create(renovacionContratoRequest request) =>
            await _repository.Create(request);

        public async Task<renovacionContratoModel> Update(renovacionContratoModel request, int id) =>
            await _repository.Update(request, id);

        public async Task<bool> Delete(int id) =>
            await _repository.Delete(id);
    }
}