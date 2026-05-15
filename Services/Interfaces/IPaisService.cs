using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IPaisService
    {
        Task<List<PaisModel>> GetAll();
        Task<PaisModel?> GetById(int id);
        Task<int> Create(PaisRequest request);
        Task<int> Update(int id, PaisRequest request);
        Task<bool> Delete(int id);
    }
}