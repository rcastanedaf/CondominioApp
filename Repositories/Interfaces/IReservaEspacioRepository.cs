using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IReservaEspacioRepository
    {
        Task<List<ReservaEspacioModel>> GetAllAsync();
        Task<List<ReservaEspacioModel>> GetByEspacio(int idEspacio);
        Task<List<ReservaEspacioModel>> GetByResidente(int idResidente);
        Task<ReservaEspacioCreateRequest> Create(ReservaEspacioCreateRequest req);
        Task<ReservaEspacioUpdateRequest> Update(ReservaEspacioUpdateRequest req);
        Task<bool> CambiarEstado(int id, string estado, int? aprobadoPor);
        Task<bool> HasOverlap(int idEspacio, string fecha, string horaInicio, string horaFin, int? excludeId = null);
    }
}
