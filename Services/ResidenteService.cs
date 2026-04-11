using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class ResidenteService : IResidenteService
    {
        private readonly IResidenteRepository _residenteRepository;
        public ResidenteService(IResidenteRepository residenteRepository)
        {
            _residenteRepository = residenteRepository;
        }

        public async Task<List<Residente>> GetAllAsync()
        {
            try
            {
                var allResidente = await _residenteRepository.GetAllAsync();

                return allResidente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Residente>> GetId(int id)
        {
            try
            {
                var idResidente = await _residenteRepository.GetId(id);

                return idResidente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Residente>> GetNombre(string nombre)
        {
            try
            {
                var nombreResidente = await _residenteRepository.GetNombre(nombre);

                return nombreResidente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResidenteUpdateRequest> UpdateResidente(ResidenteUpdateRequest editResidente)
        {
            try
            {
                var residente = await _residenteRepository.UpdateResidente(editResidente);

                return residente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResidenteCreateRequest> CreateResidente(ResidenteCreateRequest newResidente)
        {
            try
            {
                var residente = await _residenteRepository.CreateResidente(newResidente);

                return residente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeleteResidente(int id)
        {
            try
            {
                var response = _residenteRepository.DeleteResidente(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
