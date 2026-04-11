using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IcontratoRepository
    {
        Task<List<contratoModel>> GetAll();
        Task<contratoRequest> Create(contratoRequest request);
        Task<contratoModel> Update(contratoModel request, int id);
        Task<bool> Delete(int id);
    }
}