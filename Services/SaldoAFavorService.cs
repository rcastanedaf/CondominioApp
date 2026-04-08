using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class SaldoAFavorService : ISaldoAFavorService
    {
        private readonly ISaldoAFavorService _saldoAFavorRepository;
        public SaldoAFavorService(ISaldoAFavorService saldoAFavorRepository)
        {
            _saldoAFavorRepository = saldoAFavorRepository;
        }

        public async Task<List<SaldoAFavor>> GetAllAsync()
        {
            try
            {
                var allSaldoAFavor = await _saldoAFavorRepository.GetAllAsync();

                return allSaldoAFavor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SaldoAFavor>> GetId(int id)
        {
            try
            {
                var idSaldoAFavor = await _saldoAFavorRepository.GetId(id);

                return idSaldoAFavor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SaldoAFavor>> GetNombre(string nombre)
        {
            try
            {
                var nombreSaldoAFavor = await _saldoAFavorRepository.GetNombre(nombre);

                return nombreSaldoAFavor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SaldoAFavorUpdateRequest> UpdateSaldoAFavor(SaldoAFavorUpdateRequest editSaldoAFavor)
        {
            try
            {
                var saldoAFavor = await _saldoAFavorRepository.UpdateSaldoAFavor(editSaldoAFavor);

                return saldoAFavor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SaldoAFavorCreateRequest> CreateSaldoAFavor (SaldoAFavorCreateRequest newSaldoAFavor)
        {
            try
            {
                var saldoAFavor = await _saldoAFavorRepository.CreateSaldoAFavor(newSaldoAFavor);

                return saldoAFavor;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeleteSaldoAFavor(int id)
        {
            try
            {
                var response = _saldoAFavorRepository.DeleteSaldoAFavor(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
