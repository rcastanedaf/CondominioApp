using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoService(IBancoRepository bancoRepository)
        {
            _bancoRepository = bancoRepository;
        }

        public async Task<ApiResponse<List<Banco>>> GetAllAsync()
        {
            try 
            {
                var allBanco = await _bancoRepository.GetAllAsync();

                return ApiResponse<List<Banco>>.Ok(allBanco);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Banco>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Banco>>> GetId(int id)
        {
            try
            {
                var idBanco = await _bancoRepository.GetId(id);

                return ApiResponse<List<Banco>>.Ok(idBanco);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Banco>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Banco>>> GetNombre(string nombre)
        {
            try
            {
                var nombreBanco = await _bancoRepository.GetNombre(nombre);

                return ApiResponse<List<Banco>>.Ok(nombreBanco);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Banco>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Banco>>> UpdateBanco(Banco editBanco)
        {
            try
            {
                var banco = await _bancoRepository.UpdateBanco(editBanco);

                return ApiResponse<List<Banco>>.Ok(banco);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Banco>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Banco>>> CreateBanco(Banco editBanco)
        {
            try
            {
                var bus = await _bancoRepository.GetNombre(editBanco.Nombre);
                if (bus != null)
                {
                    var banco = await _bancoRepository.CreateBanco(editBanco);

                    return ApiResponse<List<Banco>>.Ok(banco);
                }
                else
                {
                    return ApiResponse<List<Banco>>.Fail("Banco ya existente");
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Banco>>.Fail(ex.Message);
            }
        }

        public async Task<ApiResponse<List<Banco>>> DeleteBanco(int id)
        {
            try
            {
                var banco = await _bancoRepository.DeleteBanco(id);
                return ApiResponse<List<Banco>>.Ok(banco);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<Banco>>.Fail(ex.Message);
            }
        }
    }
}
