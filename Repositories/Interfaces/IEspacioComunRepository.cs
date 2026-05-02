using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IEspacioComunRepository
    {
        Task<List<EspacioComunModel>> GetAllAsync();
        Task<EspacioComunCreateRequest> Create(EspacioComunCreateRequest req);
        Task<EspacioComunUpdateRequest> Update(EspacioComunUpdateRequest req);
        Task<bool> CambiarEstado(int id, string estado);
        Task<bool> Delete(int id);

    }
}
