using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IVisitaAutorizadaService
    {
        Task<List<VisitaAutorizadaModel>> GetAllAsync();
        Task<List<VisitaAutorizadaModel>> GetActivas();
        Task<VisitaAutorizadaCreateRequest> Create(VisitaAutorizadaCreateRequest req);
        Task<VisitaAutorizadaUpdateRequest> Update(VisitaAutorizadaUpdateRequest req);
        Task<bool> CambiarEstado(int id, string estado);

    }
}
