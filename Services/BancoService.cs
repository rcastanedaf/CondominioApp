using Condominio.DTOs.Request;
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

        public async Task<List<Banco>> GetAllAsync()
        {
            try
            {
                var allBanco = await _bancoRepository.GetAllAsync();

                return allBanco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Banco>> GetId(int id)
        {
            try
            {
                var idBanco = await _bancoRepository.GetId(id);

                return idBanco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Banco>> GetNombre(string nombre)
        {
            try
            {
                var nombreBanco = await _bancoRepository.GetNombre(nombre);

                return nombreBanco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BancoUpdateRequest> UpdateBanco(BancoUpdateRequest editBanco)
        {
            try
            {
                var banco = await _bancoRepository.UpdateBanco(editBanco);

                return banco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BancoCreateRequest> CreateBanco(BancoCreateRequest newBanco)
        {
            try
            {
                var banco = await _bancoRepository.CreateBanco(newBanco);

                return banco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeleteBanco(int id)
        {
            try
            {
                var response = _bancoRepository.DeleteBanco(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
