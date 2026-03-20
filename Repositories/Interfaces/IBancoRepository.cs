using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IBancoRepository
    {
        public Task<List<Banco>> GetAllAsync();
        public Task<List<Banco>> GetId(int id);
        public Task<List<Banco>> GetNombre(string nombre);
        public Task<BancoCreateRequest> CreateBanco(BancoCreateRequest newbanco);
        public Task<BancoUpdateRequest> UpdateBanco(BancoUpdateRequest editbanco);
        public Task<bool> DeleteBanco(int id);

    }
}
