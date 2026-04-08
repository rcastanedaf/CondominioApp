
using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IMetodoPagoService
    {
        public Task<MetodoPagoCreateRequest> CreateAsync(MetodoPagoCreateRequest request);
        public Task<List<MetodoPagoModel>> GetAllAsync();
        public Task<MetodoPagoModel> UpdateAsync(MetodoPagoModel request, int id);
        public Task<bool> DeleteAsync(int id);
    }
}
