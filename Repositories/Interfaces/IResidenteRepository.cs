using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IResidenteRepository
    {
        public Task<List<Residente>> GetAllAsync();
        public Task<List<Residente>> GetId(int id);
        public Task<List<Residente>> GetNombre(string nombre);
        public Task<ResidenteCreateRequest> CreateResidente(ResidenteCreateRequest newResidente);
        public Task<ResidenteUpdateRequest> UpdateResidente(ResidenteUpdateRequest editResidente);
        public Task<bool> DeleteResidente(int id);
    }
}
