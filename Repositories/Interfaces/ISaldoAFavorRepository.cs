using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ISaldoAFavorRepository
    {
        public Task<List<SaldoAFavor>> GetAllAsync();
        public Task<List<SaldoAFavor>> GetId(int id);
        public Task<List<SaldoAFavor>> GetNombre(string nombre);
        public Task<SaldoAFavorCreateRequest> CreateSaldoAFavor(SaldoAFavorCreateRequest newsaldo);
        public Task<SaldoAFavorUpdateRequest> UpdateSaldoAFavor(SaldoAFavorUpdateRequest editsaldo);
        public Task<bool> DeleteSaldoAFavor(int id);
    }
}
