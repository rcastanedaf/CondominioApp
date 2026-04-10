using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class IncidenciaService : IIncidenciaService
    {
        private readonly IIncidenciaRepository _repository;

        public IncidenciaService(IIncidenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<IncidenciaModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IncidenciaModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(IncidenciaModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(IncidenciaModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}