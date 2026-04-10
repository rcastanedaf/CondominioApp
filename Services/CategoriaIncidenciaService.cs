using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class CategoriaIncidenciaService : ICategoriaIncidenciaService
    {
        private readonly ICategoriaIncidenciaRepository _repository;

        public CategoriaIncidenciaService(ICategoriaIncidenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoriaIncidenciaModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CategoriaIncidenciaModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(CategoriaIncidenciaModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(CategoriaIncidenciaModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}