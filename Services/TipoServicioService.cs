using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class TipoServicioService : ITipoServicioService
    {
        private readonly ITipoServicioRepository _repository;

        public TipoServicioService(ITipoServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TipoServicioModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TipoServicioModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(TipoServicioModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(TipoServicioModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}