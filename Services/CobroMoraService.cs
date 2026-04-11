using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class CobroMoraService : ICobroMoraService
    {
        private readonly ICobroMoraRepository _repository;

        public CobroMoraService(ICobroMoraRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CobroMoraModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CobroMoraModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(CobroMoraModel model)
        {
            if (model.SaldoBase.HasValue && model.PorcentajeAplicado.HasValue)
            {
                model.MontoMora = model.SaldoBase.Value * (model.PorcentajeAplicado.Value / 100);
                model.AcumuladoTotal = model.SaldoBase.Value + model.MontoMora.Value;
            }

            await _repository.CreateAsync(model);
        }

        public async Task UpdateAsync(CobroMoraModel model)
        {
            if (model.SaldoBase.HasValue && model.PorcentajeAplicado.HasValue)
            {
                model.MontoMora = model.SaldoBase.Value * (model.PorcentajeAplicado.Value / 100);
                model.AcumuladoTotal = model.SaldoBase.Value + model.MontoMora.Value;
            }

            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}