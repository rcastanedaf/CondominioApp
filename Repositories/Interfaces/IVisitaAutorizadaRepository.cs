using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IVisitaAutorizadaRepository
    {
        Task<List<VisitaAutorizadaModel>> GetAllAsync();
        Task<List<VisitaAutorizadaModel>> GetActivas();
        Task<VisitaAutorizadaModel> GetById(int id);
        Task<VisitaAutorizadaCreateRequest> Create(VisitaAutorizadaCreateRequest req);
        Task<VisitaAutorizadaUpdateRequest> Update(VisitaAutorizadaUpdateRequest req);
        Task<bool> CambiarEstado(int id, string estado);

    }
}
