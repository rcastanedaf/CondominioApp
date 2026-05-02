using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IListaNegraService
    {
        Task<List<ListaNegraModel>> GetAllAsync();
        Task<ListaNegraCreateRequest> Create(ListaNegraCreateRequest req);
        Task<ListaNegraUpdateRequest> Update(ListaNegraUpdateRequest req);
        Task<bool> Desactivar(int id);

    }
}
