using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IHorarioTurnoRepository
    {
        Task<IEnumerable<HorarioTurnoModel>> GetAllAsync();
        Task<HorarioTurnoModel?> GetByIdAsync(int id);
        Task<int> CreateAsync(HorarioTurnoModel model);
        Task<int> UpdateAsync(HorarioTurnoModel model);
        Task<int> DeleteAsync(int id);
        Task<int> ToggleActivoAsync(int id, int activo);
    }
}
