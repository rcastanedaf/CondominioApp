using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoService (ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<List<CargoModel>> GetAllAsync()
        {
            try
            {
                var allCargos = await _cargoRepository.GetAllAsync();

                return allCargos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CargoCreateRequest> Create(CargoCreateRequest r)
        {
            try
            {
                var banco = await _cargoRepository.Create(r);

                return banco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CargoUpdateRequest> Update(CargoUpdateRequest r)
        {
            try
            {
                var banco = await _cargoRepository.Update(r);

                return banco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> Delete(int id)
        {
            try
            {
                var response = _cargoRepository.Delete(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
