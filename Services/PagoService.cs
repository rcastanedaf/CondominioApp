using Condominio.Models;
using Condominio.Repositories;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _repository;

        public PagoService(IPagoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PagoModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<PagoModel>> GetByResidenteAsync(int idResidente)
        {
            try
            {
                var allPago = await _repository.GetByResidenteAsync(idResidente);

                return allPago;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PagoModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<PagoModel>> GetByFacturaAsync(int idFactura)
        {
            return await _repository.GetByFacturaAsync(idFactura);
        }

        public async Task CreateAsync(PagoModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(PagoModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
