using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ILogAuditoriaService
    {
        Task<List<LogAuditoriaModel>> GetAllAsync(int top = 500);
        Task Registrar(LogAuditoriaCreateRequest log);
    }
}
