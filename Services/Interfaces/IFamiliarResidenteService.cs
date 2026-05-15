using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IFamiliarResidenteService
    {
        Task<IEnumerable<FamiliarResidenteModel>> GetAllAsync();
        Task<IEnumerable<FamiliarResidenteModel>> GetByResidenteAsync(int idResidente);
        Task<FamiliarResidenteModel?> GetByIdAsync(int id);
        Task<int> CreateAsync(FamiliarResidenteCreateRequest request);
        Task<int> UpdateAsync(int id, FamiliarResidenteUpdateRequest request);
        Task<int> DeleteAsync(int id);
        Task<int> ToggleActivoAsync(int id, int activo);
    }
}