using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ITipoMonedaService
    {
        public Task<List<TipoMonedaModel>> GetAllAsync();

        public Task<TipoMonedaModel> UpdateAsync(TipoMonedaModel request, int id);

        public Task<TipoMonedaCreateRequest> CreateAsync(TipoMonedaCreateRequest request);

        public Task<bool> DeleteAsync(int id);
    }
}
