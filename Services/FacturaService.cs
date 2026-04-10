using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _repository;

        public FacturaService(IFacturaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FacturaModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FacturaModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<FacturaModel>> GetByPropiedadAsync(int idPropiedad)
        {
            return await _repository.GetByPropiedadAsync(idPropiedad);
        }

        public async Task CreateAsync(FacturaModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(FacturaModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
