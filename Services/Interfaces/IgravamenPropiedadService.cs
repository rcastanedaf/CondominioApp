using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IgravamenPropiedadService
    {

        public Task<List<gravamenPropiedadModel>> GetAll();
        public Task<gravamenPropiedadRequest> Create(gravamenPropiedadRequest request);
        public Task<gravamenPropiedadModel> Update(gravamenPropiedadModel request, int id);
        public Task<bool> Delete(int id);
    }
}
