using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;


namespace Condominio.Services
{
    public class ParentescoService : IParentescoService
    {
        private readonly IParentescoRepository _repository;

        public ParentescoService(IParentescoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ParentescoModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ParentescoModel> Create(ParentescoRequest request)
        {
            var model = new ParentescoModel
            {
                Nombre = request.Nombre
            };

            return await _repository.Create(model);
        }

        public async Task<ParentescoModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<ParentescoModel> Update(int id, ParentescoRequest request)
        {
            var model = new ParentescoModel
            {
                Nombre = request.Nombre
            };

            return await _repository.Update(id, model);
        }

        public async Task<ParentescoModel> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}