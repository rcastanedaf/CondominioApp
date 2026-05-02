using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IRegistroAccesoService
    {
        Task<List<RegistroAccesoModel>> GetAllAsync(int? top);
        Task<List<RegistroAccesoModel>> GetByFecha(string desde, string hasta);
        Task<RegistroAccesoCreateRequest> Create(RegistroAccesoCreateRequest req);

    }
}
