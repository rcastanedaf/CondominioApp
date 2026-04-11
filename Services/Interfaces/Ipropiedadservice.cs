using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IpropiedadService
    {
        Task<List<propiedadModel>> GetAll();
        Task<propiedadRequest> Create(propiedadRequest request);
        Task<propiedadModel> Update(propiedadModel request, int id);
        Task<bool> Delete(int id);
    }
}