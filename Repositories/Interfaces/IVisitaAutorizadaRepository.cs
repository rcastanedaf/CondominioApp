using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IVisitaAutorizadaRepository
    {
        Task<List<VisitaAutorizadaModel>> GetAllAsync();
        Task<List<VisitaAutorizadaModel>> GetActivas();
        Task<VisitaAutorizadaModel?> GetById(int id);
        Task<int> Create(VisitaAutorizadaCreateRequest req);
        Task<int> Update(int id, VisitaAutorizadaUpdateRequest req);
        Task<bool> CambiarEstado(int id, string estado);
        Task<bool> Delete(int id);
    }
}