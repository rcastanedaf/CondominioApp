using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class TipoContratoService : ITipoContratoService
    {
        private readonly ITipoContratoRepository _repository;

        public TipoContratoService(ITipoContratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<TipoContratoModel>>> GetAllAsync()
        {
            try
            {
                var data = await _repository.GetAllAsync();
                return ApiResponse<List<TipoContratoModel>>.Ok(data);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<TipoContratoModel>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<TipoContratoModel>> GetByIdAsync(int id)
        {
            try
            {
                var data = await _repository.GetByIdAsync(id);

                if (data == null)
                    return ApiResponse<TipoContratoModel>.Fail("Tipo contrato no encontrado");

                return ApiResponse<TipoContratoModel>.Ok(data);
            }
            catch (Exception ex)
            {
                return ApiResponse<TipoContratoModel>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<TipoContratoModel>> CreateAsync(TipoContratoModel model)
        {
            try
            {
                var data = await _repository.CreateAsync(model);
                return ApiResponse<TipoContratoModel>.Ok(data);
            }
            catch (Exception ex)
            {
                return ApiResponse<TipoContratoModel>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> UpdateAsync(TipoContratoModel model)
        {
            try
            {
                var result = await _repository.UpdateAsync(model);

                if (!result)
                    return ApiResponse<bool>.Fail("Tipo contrato no encontrado");

                return ApiResponse<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);

                if (!result)
                    return ApiResponse<bool>.Fail("Tipo contrato no encontrado");

                return ApiResponse<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(ex.Message);
            }
        }
    }
}