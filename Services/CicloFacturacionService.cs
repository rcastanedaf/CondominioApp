using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class CicloFacturacionService : ICicloFacturacionService
    {
        private readonly ICicloFacturacionRepository _repository;

        public CicloFacturacionService(ICicloFacturacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CicloFacturacionModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CicloFacturacionModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<CicloFacturacionModel>> GetByPropiedadAsync(int idPropiedad)
        {
            return await _repository.GetByPropiedadAsync(idPropiedad);
        }

        public async Task CreateAsync(CicloFacturacionModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(CicloFacturacionModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
