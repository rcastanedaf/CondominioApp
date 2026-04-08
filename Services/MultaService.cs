using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class MultaService : IMultaService
    {
        private readonly IMultaService _multaRepository;
        public MultaService(IMultaService multaRepository)
        {
            _multaRepository = multaRepository;
        }

        public async Task<List<Multa>> GetAllAsync()
        {
            try
            {
                var allMulta = await _multaRepository.GetAllAsync();

                return allMulta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Multa>> GetId(int id)
        {
            try
            {
                var idMulta = await _multaRepository.GetId(id);

                return idMulta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Multa>> GetNombre(string nombre)
        {
            try
            {
                var nombreMulta = await _multaRepository.GetNombre(nombre);

                return nombreMulta;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MultaUpdateRequest> UpdateMulta(MultaUpdateRequest editMulta)
        {
            try
            {
                var multa = await _multaRepository.UpdateMulta(editMulta);

                return multa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MultaCreateRequest> CreateMulta(MultaCreateRequest newMulta)
        {
            try
            {
                var multa = await _multaRepository.CreateMulta(newMulta);

                return multa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeleteMulta(int id)
        {
            try
            {
                var response = _multaRepository.DeleteMulta(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
