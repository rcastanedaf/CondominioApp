using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class gravamenPropiedadService : IgravamenPropiedadService
    {
        private readonly IgravamenPropiedadRepository _repository;

        public gravamenPropiedadService(IgravamenPropiedadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<gravamenPropiedadModel>> GetAll()
        {
            var data = await _repository.GetAll();
            return data;
        }

        public async Task<gravamenPropiedadRequest> Create(gravamenPropiedadRequest request)
        {
            var response = await _repository.Create(request);
            return response;
        }

        public async Task<gravamenPropiedadModel> Update(gravamenPropiedadModel request, int id)
        {
            var response = await _repository.Update(request, id);
            return response;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _repository.Delete(id);
            return response;
        }
    }
}