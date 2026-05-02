using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ICargoService
    {
        public Task<List<CargoModel>> GetAllAsync();
        public Task<CargoCreateRequest> Create(CargoCreateRequest r);
        public Task<CargoUpdateRequest> Update(CargoUpdateRequest r);
        public Task<bool> Delete(int id);
    }
}
