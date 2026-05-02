using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class LogAuditoriaService : ILogAuditoriaService
    {
        private readonly ILogAuditoriaRepository _repo;
        public LogAuditoriaService(ILogAuditoriaRepository repo) => _repo = repo;
        public Task<List<LogAuditoriaModel>> GetAllAsync(int top = 500) => _repo.GetAllAsync(top);
        public Task Registrar(LogAuditoriaCreateRequest log) => _repo.Registrar(log);
    }
}
