using Condominio.DTOs.Response;
using Condominio.Models;
namespace Condominio.Services.Interfaces
{
    public interface IBancoService
    {
        public Task<ApiResponse<List<Banco>>> GetAllAsync();
        public Task<ApiResponse<List<Banco>>> GetId(int id);
        public Task<ApiResponse<List<Banco>>> GetNombre(string nombre);
        public Task<ApiResponse<List<Banco>>> CreateBanco(Banco newbanco);
        public Task<ApiResponse<List<Banco>>> UpdateBanco(Banco editbanco);
        public Task<ApiResponse<List<Banco>>> DeleteBanco(int id);
    }
}
