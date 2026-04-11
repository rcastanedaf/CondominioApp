using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IcontratoService
    {
        Task<List<contratoModel>> GetAll();
        Task<contratoRequest> Create(contratoRequest request);
        Task<contratoModel> Update(contratoModel request, int id);
        Task<bool> Delete(int id);
    }
}
