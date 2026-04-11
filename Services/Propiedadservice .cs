using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class propiedadService : IpropiedadService
    {
        private readonly IpropiedadRepository _repository;

        public propiedadService(IpropiedadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<propiedadModel>> GetAll() =>
            await _repository.GetAll();

        public async Task<propiedadRequest> Create(propiedadRequest request) =>
            await _repository.Create(request);

        public async Task<propiedadModel> Update(propiedadModel request, int id) =>
            await _repository.Update(request, id);

        public async Task<bool> Delete(int id) =>
            await _repository.Delete(id);
    }
}