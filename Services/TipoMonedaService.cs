using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class TipoMonedaService : ITipoMonedaService
    {
        private readonly ITipoMonedaRepository _tipoMonedaRepository;

        public TipoMonedaService(ITipoMonedaRepository tipoMonedaRepository)
        {
            _tipoMonedaRepository = tipoMonedaRepository;
        }

        public async Task<List<TipoMonedaModel>> GetAllAsync()
        {
            try
            {
                var tiposMoneda = await _tipoMonedaRepository.GetAllAsync();

                return tiposMoneda;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TipoMonedaModel> UpdateAsync(TipoMonedaModel request, int id)
        {
            try
            {
                var tipoMoneda = await _tipoMonedaRepository.UpdateAsync(request, id);

                return tipoMoneda;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<TipoMonedaCreateRequest> CreateAsync(TipoMonedaCreateRequest request)
        {
            try
            {
                var response = _tipoMonedaRepository.CreateAsync(request);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = _tipoMonedaRepository.DeleteAsync(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
