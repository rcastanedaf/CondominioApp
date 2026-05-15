using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class HorarioTurnoService : IHorarioTurnoService
    {
        private readonly IHorarioTurnoRepository _repo;

        public HorarioTurnoService(IHorarioTurnoRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<HorarioTurnoModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<HorarioTurnoModel?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<int> CreateAsync(HorarioTurnoModel model) => _repo.CreateAsync(model);
        public Task<int> UpdateAsync(HorarioTurnoModel model) => _repo.UpdateAsync(model);
        public Task<int> DeleteAsync(int id) => _repo.DeleteAsync(id);
        public Task<int> ToggleActivoAsync(int id, int activo) => _repo.ToggleActivoAsync(id, activo);
    }
}
