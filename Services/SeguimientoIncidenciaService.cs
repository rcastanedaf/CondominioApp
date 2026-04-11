using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class SeguimientoIncidenciaService : ISeguimientoIncidenciaService
    {
        private readonly ISeguimientoIncidenciaRepository _repository;

        public SeguimientoIncidenciaService(ISeguimientoIncidenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SeguimientoIncidenciaModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<List<SeguimientoIncidenciaModel>> GetByIncidenciaAsync(int id)
        {
            return await _repository.GetByIncidenciaAsync(id);
        }

        public async Task<SeguimientoIncidenciaModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(SeguimientoIncidenciaModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(SeguimientoIncidenciaModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}