using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _repo;
        public EmpleadoService(IEmpleadoRepository repo) => _repo = repo;
        public Task<List<EmpleadoModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<EmpleadoCreateRequest> Create(EmpleadoCreateRequest req) => _repo.Create(req);
        public Task<EmpleadoUpdateRequest> Update(EmpleadoUpdateRequest req) => _repo.Update(req);
        public Task<bool> Delete(int id) => _repo.Delete(id);
    }
}
