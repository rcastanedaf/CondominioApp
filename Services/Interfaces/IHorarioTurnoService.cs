using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IHorarioTurnoService
    {
        Task<IEnumerable<HorarioTurnoModel>> GetAllAsync();
        Task<HorarioTurnoModel?> GetByIdAsync(int id);
        Task<int> CreateAsync(HorarioTurnoModel model);
        Task<int> UpdateAsync(HorarioTurnoModel model);
        Task<int> DeleteAsync(int id);
        Task<int> ToggleActivoAsync(int id, int activo);
    }
}
