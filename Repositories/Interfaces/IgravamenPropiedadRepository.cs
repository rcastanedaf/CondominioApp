using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IgravamenPropiedadRepository
    {
        Task<List<gravamenPropiedadModel>> GetAll();
        Task<gravamenPropiedadRequest> Create(gravamenPropiedadRequest request);
        Task<gravamenPropiedadModel> Update(gravamenPropiedadModel request, int id);
        Task<bool> Delete(int id);
    }
}
