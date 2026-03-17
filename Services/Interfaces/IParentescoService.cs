using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IParentescoService
    {
        Task<List<ParentescoModel>> GetAll();
        Task<ParentescoModel> Create(ParentescoRequest request);
        Task<ParentescoModel> GetById(int id);
        Task<ParentescoModel> Update(int id, ParentescoRequest request);
        Task<ParentescoModel> Delete(int id);
    }
}