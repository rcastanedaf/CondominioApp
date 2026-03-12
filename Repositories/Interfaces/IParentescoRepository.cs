using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IParentescoRepository
    {
        public Task<List<ParentescoModel>> GetAll();
        Task<ParentescoModel> Create(ParentescoModel model);//Para crear un nuevo parentesto
        Task<ParentescoModel> GetById(int id);//Para bsucar pariente por id
        Task<ParentescoModel> Update(int id, ParentescoModel model);
        Task<ParentescoModel> Delete(int id);
    }
}
