using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IParentescoRepository
    {
        public Task<List<ParentescoModel>> GetAll();
        public Task<ParentescoRequest> Create(ParentescoRequest request);//Para crear un nuevo parentesto
        //Task<ParentescoModel> GetById(int id);//Para bsucar pariente por id
        Task<ParentescoModel> Update(ParentescoModel request, int id);
        Task<bool> Delete(int id);
    }
}
