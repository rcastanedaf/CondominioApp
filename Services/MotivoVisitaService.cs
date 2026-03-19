using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class MotivoVisitaService : IMotivoVisitaService
    {
        private readonly IMotivoVisitaRepository _repository;

        public MotivoVisitaService(IMotivoVisitaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<List<MotivoVisitaModel>>> GetAllAsync()
        {
            try
            {
                var data = await _repository.GetAllAsync();
                return ApiResponse<List<MotivoVisitaModel>>.Ok(data);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<MotivoVisitaModel>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<MotivoVisitaModel>> GetByIdAsync(int id)
        {
            try
            {
                var data = await _repository.GetByIdAsync(id);

                if (data == null)
                    return ApiResponse<MotivoVisitaModel>.Fail("Motivo no encontrado");

                return ApiResponse<MotivoVisitaModel>.Ok(data);
            }
            catch (Exception ex)
            {
                return ApiResponse<MotivoVisitaModel>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<MotivoVisitaModel>> CreateAsync(MotivoVisitaModel model)
        {
            try
            {
                var data = await _repository.CreateAsync(model);
                return ApiResponse<MotivoVisitaModel>.Ok(data);
            }
            catch (Exception ex)
            {
                return ApiResponse<MotivoVisitaModel>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> UpdateAsync(MotivoVisitaModel model)
        {
            try
            {
                var result = await _repository.UpdateAsync(model);

                if (!result)
                    return ApiResponse<bool>.Fail("Motivo no encontrado");

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
                    return ApiResponse<bool>.Fail("Motivo no encontrado");

                return ApiResponse<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(ex.Message);
            }
        }
    }
}