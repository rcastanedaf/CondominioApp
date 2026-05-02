using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> GetAllAsync();
        Task<UsuarioModel> GetByUsername(string username);
        Task<UsuarioCreateRequest> Create(UsuarioCreateRequest req, string passwordHash, string salt);
        Task<bool> Update(UsuarioUpdateRequest req);
        Task<bool> CambiarPassword(int id, string newHash, string salt);
        Task<bool> Desbloquear(int id);
        Task<(string hash, string salt)> GetCredenciales(string username);
        Task<object> Login(string username, string password);
    }
}
