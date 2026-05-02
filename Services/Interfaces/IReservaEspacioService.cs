using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IReservaEspacioService
    {
        Task<List<ReservaEspacioModel>> GetAllAsync();
        Task<List<ReservaEspacioModel>> GetByEspacio(int id);
        Task<List<ReservaEspacioModel>> GetByResidente(int id);
        Task<ReservaEspacioCreateRequest> Create(ReservaEspacioCreateRequest req);
        Task<ReservaEspacioUpdateRequest> Update(ReservaEspacioUpdateRequest req);
        Task<bool> CambiarEstado(int id, string estado, int? aprobadoPor);

    }
}
