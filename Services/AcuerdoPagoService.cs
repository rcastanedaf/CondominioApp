using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class AcuerdoPagoService : IAcuerdoPagoService
    {
        private readonly IAcuerdoPagoRepository _repo;

        public AcuerdoPagoService(IAcuerdoPagoRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<AcuerdoPagoModel>> GetAllAsync() => _repo.GetAllAsync();
        public Task<IEnumerable<AcuerdoPagoModel>> GetByResidenteAsync(int idResidente) => _repo.GetByResidenteAsync(idResidente);
        public Task<AcuerdoPagoModel?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<int> CreateAsync(AcuerdoPagoCreateRequest request) => _repo.CreateAsync(request);
        public Task<int> UpdateAsync(int id, AcuerdoPagoUpdateRequest request) => _repo.UpdateAsync(id, request);
        public Task<int> DeleteAsync(int id) => _repo.DeleteAsync(id);
        public Task<IEnumerable<CuotaAcuerdoModel>> GetCuotasAsync(int idAcuerdo) => _repo.GetCuotasAsync(idAcuerdo);
        public Task<int> PagarCuotaAsync(int idCuota) => _repo.PagarCuotaAsync(idCuota);
    }
}