using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IRegistroAccesoRepository
    {
        Task<List<RegistroAccesoModel>> GetAllAsync(int? top = 200);
        Task<List<RegistroAccesoModel>> GetByFecha(string fechaDesde, string fechaHasta);
        Task<RegistroAccesoCreateRequest> Create(RegistroAccesoCreateRequest req);

    }
}
