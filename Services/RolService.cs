using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _repo;

        public RolService(IRolRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<RolModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<RolModel?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<int> CreateAsync(RolCreateRequest request) => _repo.CreateAsync(request);
        public Task<int> UpdateAsync(int id, RolCreateRequest request) => _repo.UpdateAsync(id, request);
        public Task<int> ToggleActivoAsync(int id, int activo) => _repo.ToggleActivoAsync(id, activo);
        public Task<int> DeleteAsync(int id) => _repo.DeleteAsync(id);
        public Task<IEnumerable<PermisoModel>> GetPermisosAsync(int idRol) => _repo.GetPermisosAsync(idRol);
        public Task<int> AsignarPermisoAsync(int idRol, int idPermiso) => _repo.AsignarPermisoAsync(idRol, idPermiso);
        public Task<int> QuitarPermisoAsync(int idRol, int idPermiso) => _repo.QuitarPermisoAsync(idRol, idPermiso);
    }
}