using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IHorarioTurnoRepository
    {
        Task<List<HorarioTurnoModel>> GetAllAsync();
        Task<List<HorarioTurnoModel>> GetByEmpleado(int idEmpleado);
        Task<HorarioTurnoRequest> Create(HorarioTurnoRequest req);
        Task<bool> Delete(int id);
    }
}
