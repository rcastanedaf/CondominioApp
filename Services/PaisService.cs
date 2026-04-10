using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories;
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
            try
            {
                var pais = await _paisRepository.GetAll();

                return pais;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaisRequest> Create(PaisRequest request)
        {
            try
            {
                var response = await _paisRepository.Create(request);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*public async Task<PaisModel> GetById(int id)
        {
            return await _paisRepository.GetById(id);
        }*/

        public async Task<PaisModel> Update(PaisModel request, int id)
        {
            try
            {
                var tipoMoneda = await _paisRepository.Update(request, id);

                return tipoMoneda;

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
                var response = _paisRepository.Delete(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
