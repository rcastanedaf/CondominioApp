using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ILogAuditoriaRepository
    {
        Task<List<LogAuditoriaModel>> GetAllAsync(int top = 500);
        Task Registrar(LogAuditoriaCreateRequest log);
    }
}
