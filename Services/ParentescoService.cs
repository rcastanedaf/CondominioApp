using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories;
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
            try
            {
                var parentesco = await _repository.GetAll();

                return parentesco;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ParentescoRequest> Create(ParentescoRequest request)
        {
            try
            {
                var response = await _repository.Create(request);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ParentescoModel> Update(ParentescoModel request, int id)
        {
            try
            {
                var parentesco = await _repository.Update(request, id);

                return parentesco;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                var response = _repository.Delete(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}