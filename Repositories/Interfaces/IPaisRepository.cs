using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IPaisRepository
    {
        public Task<List<PaisModel>> GetAll();
        public Task<PaisRequest> Create(PaisRequest request);
        //Task<PaisModel> GetById(int id);
        Task<PaisModel> Update(PaisModel request, int id);
        Task<bool> Delete(int id);
    }
}
