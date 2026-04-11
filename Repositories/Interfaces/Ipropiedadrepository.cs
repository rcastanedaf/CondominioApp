using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IpropiedadRepository
    {
        Task<List<propiedadModel>> GetAll();
        Task<propiedadRequest> Create(propiedadRequest request);
        Task<propiedadModel> Update(propiedadModel request, int id);
        Task<bool> Delete(int id);
    }
}