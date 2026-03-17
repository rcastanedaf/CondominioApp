using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class PaisService : IPaisService
    {
        private readonly IPaisRepository _paisRepository;

        public PaisService(IPaisRepository repository)
        {
            _paisRepository = repository;
        }

        public async Task<List<PaisModel>> GetAll() 
        {
            return await _paisRepository.GetAll();
        }

        public async Task<PaisModel> Create(PaisRequest request)
        {
            var model = new PaisModel
            {
                Codigo = request.Codigo,
                Nombre = request.Nombre
            };

            return await _paisRepository.Create(model);
        }

        public async Task<PaisModel> GetById(int id)
        {
            return await _paisRepository.GetById(id);
        }

        public async Task<PaisModel> Update(int id, PaisRequest request)
        {
            var model = new PaisModel
            {
                Codigo = request.Codigo,
                Nombre = request.Nombre
            };

            return await _paisRepository.Update(id, model);
        }

        public async Task<PaisModel> Delete(int id)
        {
            return await _paisRepository.Delete(id);
        }
    }
}
