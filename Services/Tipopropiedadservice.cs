using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class tipoPropiedadService : ItipoPropiedadService
    {
        private readonly ItipoPropiedadRepository _repository;

        public tipoPropiedadService(ItipoPropiedadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<tipoPropiedadModel>> GetAll() =>
            await _repository.GetAll();

        public async Task<tipoPropiedadRequest> Create(tipoPropiedadRequest request) =>
            await _repository.Create(request);

        public async Task<tipoPropiedadModel> Update(tipoPropiedadModel request, int id) =>
            await _repository.Update(request, id);

        public async Task<bool> Delete(int id) =>
            await _repository.Delete(id);
    }
}