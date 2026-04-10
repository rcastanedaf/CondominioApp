using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private readonly IDetalleFacturaRepository _repository;

        public DetalleFacturaService(IDetalleFacturaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DetalleFacturaModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DetalleFacturaModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<DetalleFacturaModel>> GetByFacturaAsync(int idFactura)
        {
            return await _repository.GetByFacturaAsync(idFactura);
        }

        public async Task CreateAsync(DetalleFacturaModel model)
        {
            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(DetalleFacturaModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
