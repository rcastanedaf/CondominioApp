using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IPaisService
    {
        Task<List<PaisModel>> GetAll();
        Task<PaisModel> Create(PaisRequest request);
        Task<PaisModel> GetById(int id);
        Task<PaisModel> Update(int id, PaisRequest request);
        Task<PaisModel> Delete(int id);
    }
}
