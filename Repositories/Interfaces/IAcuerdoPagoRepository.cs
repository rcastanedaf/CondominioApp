using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IAcuerdoPagoRepository
    {
        Task<IEnumerable<AcuerdoPagoModel>> GetAllAsync();
        Task<IEnumerable<AcuerdoPagoModel>> GetByResidenteAsync(int idResidente);
        Task<AcuerdoPagoModel?> GetByIdAsync(int id);
        Task<int> CreateAsync(AcuerdoPagoCreateRequest request);
        Task<int> UpdateAsync(int id, AcuerdoPagoUpdateRequest request);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<CuotaAcuerdoModel>> GetCuotasAsync(int idAcuerdo);
        Task<int> PagarCuotaAsync(int idCuota);
    }
}