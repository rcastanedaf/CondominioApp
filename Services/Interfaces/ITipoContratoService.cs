using Condominio.DTOs.Response;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface ITipoContratoService
    {
        Task<ApiResponse<List<TipoContratoModel>>> GetAllAsync();

        Task<ApiResponse<TipoContratoModel>> GetByIdAsync(int id);

        Task<ApiResponse<TipoContratoModel>> CreateAsync(TipoContratoModel model);

        Task<ApiResponse<bool>> UpdateAsync(TipoContratoModel model);

        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}