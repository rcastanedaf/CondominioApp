using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
namespace Condominio.Services.Interfaces
{
    public interface IBancoService
    {
        public Task<List<Banco>> GetAllAsync();
        public Task<List<Banco>> GetId(int id);
        public Task<List<Banco>> GetNombre(string nombre);
        public Task<BancoCreateRequest> CreateBanco(BancoCreateRequest newbanco);
        public Task<BancoUpdateRequest> UpdateBanco(BancoUpdateRequest editbanco);
        public Task<bool> DeleteBanco(int id);
    }
}
