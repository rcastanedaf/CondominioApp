using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IMotivoVisitaRepository
    {
        Task<List<MotivoVisitaModel>> GetAllAsync();
        Task<MotivoVisitaModel?> GetByIdAsync(int id);
        Task<MotivoVisitaModel> CreateAsync(MotivoVisitaModel model);
        Task<bool> UpdateAsync(MotivoVisitaModel model);
        Task<bool> DeleteAsync(int id);
    }
}