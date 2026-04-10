using Condominio.DTOs.Request;
using Condominio.Models;
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
            catch (Exception ex)
            {
                throw new Exception("Error al obtener tipos de moneda", ex);
            }
        }

        public async Task<TipoMonedaModel> UpdateAsync(TipoMonedaModel request, int id)
        {
            try
            {
                var tipoMoneda = await _tipoMonedaRepository.UpdateAsync(request, id);

                return tipoMoneda;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar tipo de moneda", ex);
            }
        }

        public Task<TipoMonedaCreateRequest> CreateAsync(TipoMonedaCreateRequest request)
        {
            try
            {
                var response = _tipoMonedaRepository.CreateAsync(request);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear tipo de moneda", ex);
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            try
            {
                var response = _tipoMonedaRepository.DeleteAsync(id);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar tipo de moneda", ex);
            }
        }
    }
}
