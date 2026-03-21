using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IPaisService
    {
        public Task<List<PaisModel>> GetAll();
        public Task<PaisRequest> Create(PaisRequest request);
        //public Task<PaisModel> GetById(int id);
        public Task<PaisModel> Update(PaisModel request, int id);
        public Task<bool> Delete(int id);
    }
}
