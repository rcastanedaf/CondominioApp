using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class CuentaPorCobrarService : ICuentaPorCobrarService
    {
        private readonly ICuentaPorCobrarRepository _repository;

        public CuentaPorCobrarService(ICuentaPorCobrarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CuentaPorCobrarModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CuentaPorCobrarModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<CuentaPorCobrarModel>> GetByResidenteAsync(int idResidente)
        {
            return await _repository.GetByResidenteAsync(idResidente);
        }

        public async Task CreateAsync(CuentaPorCobrarModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(CuentaPorCobrarModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
