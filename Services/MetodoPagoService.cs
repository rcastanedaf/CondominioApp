using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class MetodoPagoService : IMetodoPagoService
    {
        private readonly IMetodoPagoRepository _metodoPagoRepository;

        public MetodoPagoService(IMetodoPagoRepository metodoPagoRepository)
        {
            _metodoPagoRepository = metodoPagoRepository;
        }

        public async Task<MetodoPagoCreateRequest> CreateAsync(MetodoPagoCreateRequest request)
        {
            try
            {
                var data = await _metodoPagoRepository.CreateAsync(request);
                return data;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al crear el método de pago", ex);
            }
        }

        public async Task<List<MetodoPagoModel>> GetAllAsync()
        {
            try
            {
                var data = await _metodoPagoRepository.GetAllAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el método de pago", ex);
            }
        }

        public async Task<MetodoPagoModel> UpdateAsync(MetodoPagoModel request, int id)
        {
            try
            {
                var data = await _metodoPagoRepository.UpdateAsync(request, id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el método de pago", ex);
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var data = await _metodoPagoRepository.DeleteAsync(id);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el método de pago", ex);
            }
        }
    }
}
