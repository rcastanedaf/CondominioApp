using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class ServicioActivoService : IServicioActivoService
    {
        private readonly IServicioActivoRepository _repo;

        public ServicioActivoService(IServicioActivoRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<ServicioActivoModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<IEnumerable<ServicioActivoModel>> GetByPropiedadAsync(int idProp) => _repo.GetByPropiedadAsync(idProp);
        public Task<ServicioActivoModel?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<int> CreateAsync(ServicioActivoCreateRequest request) => _repo.CreateAsync(request);
        public Task<int> UpdateAsync(int id, ServicioActivoUpdateRequest request) => _repo.UpdateAsync(id, request);
        public Task<int> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}