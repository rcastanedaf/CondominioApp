using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IMultaService
    {
        public Task<List<Multa>> GetAllAsync();
        public Task<List<Multa>> GetId(int id);
        public Task<List<Multa>> GetNombre(string nombre);
        public Task<MultaCreateRequest> CreateMulta(MultaCreateRequest newMulta);
        public Task<MultaUpdateRequest> UpdateMulta(MultaUpdateRequest editMulta);
        public Task<bool> DeleteMulta(int id);
    }
}
