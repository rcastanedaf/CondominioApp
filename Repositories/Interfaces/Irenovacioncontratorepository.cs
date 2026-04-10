using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IrenovacionContratoRepository
    {
        Task<List<renovacionContratoModel>> GetAll();
        Task<renovacionContratoRequest> Create(renovacionContratoRequest request);
        Task<renovacionContratoModel> Update(renovacionContratoModel request, int id);
        Task<bool> Delete(int id);
    }
}
