using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IPaisRepository
    {
        public Task<List<PaisModel>> GetAll();
        Task<PaisModel> Create(PaisModel model);
        Task<PaisModel> GetById(int id);
        Task<PaisModel> Update(int id, PaisModel model);
        Task<PaisModel> Delete(int id);
    }
}
