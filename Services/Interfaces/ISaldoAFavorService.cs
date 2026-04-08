using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ISaldoAFavorService
    {
        public Task<List<SaldoAFavor>> GetAllAsync();
        public Task<List<SaldoAFavor>> GetId(int id);
        public Task<List<SaldoAFavor>> GetNombre(string nombre);
        public Task<SaldoAFavorCreateRequest> CreateSaldoAFavor(SaldoAFavorCreateRequest newSaldoAFavor);
        public Task<SaldoAFavorUpdateRequest> UpdateSaldoAFavor(SaldoAFavorUpdateRequest editSaldoAFavor);
        public Task<bool> DeleteSaldoAFavor(int id);
    }
}
