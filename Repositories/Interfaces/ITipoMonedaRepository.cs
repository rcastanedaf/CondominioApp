using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ITipoMonedaRepository
    {
        public Task<TipoMonedaCreateRequest> CreateAsync(TipoMonedaCreateRequest request);
        public Task<bool> DeleteAsync(int id);
        public Task<List<TipoMonedaModel>> GetAllAsync();
        public Task<TipoMonedaModel> UpdateAsync(TipoMonedaModel request, int id);
    }
}
