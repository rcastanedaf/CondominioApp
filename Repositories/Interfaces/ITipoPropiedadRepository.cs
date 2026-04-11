using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface ITipoPropiedadRepository
    {
        public Task<List<Tipo_Propiedad>> GetAllAsync();
        public Task<List<Tipo_Propiedad>> GetId(int id);
        public Task<List<Tipo_Propiedad>> GetNombre(string nombre);
        public Task<TipoPropiedadCreateRequest> CreateTipoPropiedad(TipoPropiedadCreateRequest newTipoPropiedad);
        public Task<TipoPropiedadUpdateRequest> UpdateTipoPropiedad(TipoPropiedadUpdateRequest editTipoPropiedad);
        public Task<bool> DeleteTipoPropiedad(int id);
    }
}
