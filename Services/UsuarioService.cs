using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;
using Org.BouncyCastle.Crypto.Generators;

namespace Condominio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        public UsuarioService(IUsuarioRepository repo) => _repo = repo;
        public Task<List<UsuarioModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<UsuarioCreateRequest> Create(UsuarioCreateRequest req, string passwordHash, string salt) => _repo.Create(req, passwordHash, salt);
        public Task<bool> Update(UsuarioUpdateRequest req) => _repo.Update(req);
        public async Task<bool> CambiarPassword(int id, string newHash, string salt)
        {
            //var hash = BCrypt.Net.BCrypt.HashPassword(req.Password_Nueva);
            return await _repo.CambiarPassword(id, newHash, salt);
        }
        public Task<bool> Desbloquear(int id) => _repo.Desbloquear(id);

        public Task<UsuarioModel> GetByUsername(string username) => _repo.GetByUsername(username);

        public Task<(string hash, string salt)> GetCredenciales(string username) => _repo.GetCredenciales(username);

        public async Task<object> Login(string username, string password)
        {
            return await _repo.Login(username, password);
        }
    }
}
