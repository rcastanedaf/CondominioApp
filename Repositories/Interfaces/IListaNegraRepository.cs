using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IListaNegraRepository
    {
        Task<List<ListaNegraModel>> GetAllAsync();
        Task<ListaNegraModel> GetById(int id);
        Task<ListaNegraCreateRequest> Create(ListaNegraCreateRequest req);
        Task<ListaNegraUpdateRequest> Update(ListaNegraUpdateRequest req);
        Task<bool> Desactivar(int id);

    }
}
