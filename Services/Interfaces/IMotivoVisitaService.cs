using Condominio.DTOs.Response;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IMotivoVisitaService
    {
        Task<ApiResponse<List<MotivoVisitaModel>>> GetAllAsync();

        Task<ApiResponse<MotivoVisitaModel>> GetByIdAsync(int id);

        Task<ApiResponse<MotivoVisitaModel>> CreateAsync(MotivoVisitaModel model);

        Task<ApiResponse<bool>> UpdateAsync(MotivoVisitaModel model);

        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}