using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class TipoPropiedadService : ITipoPropiedadService
    {
        private readonly ITipoPropiedadRepository _tipoPropiedadRepository;
        public TipoPropiedadService(ITipoPropiedadRepository tipoPropiedadRepository)
        {
            _tipoPropiedadRepository = tipoPropiedadRepository;
        }

        public async Task<List<Tipo_Propiedad>> GetAllAsync()
        {
            try
            {
                var allTipoPropiedad = await _tipoPropiedadRepository.GetAllAsync();

                return allTipoPropiedad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Tipo_Propiedad>> GetId(int id)
        {
            try
            {
                var idTipoPropiedad = await _tipoPropiedadRepository.GetId(id);

                return idTipoPropiedad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Tipo_Propiedad>> GetNombre(string nombre)
        {
            try
            {
                var nombreTipoPropiedad = await _tipoPropiedadRepository.GetNombre(nombre);

                return nombreTipoPropiedad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TipoPropiedadUpdateRequest> UpdateTipoPropiedad(TipoPropiedadUpdateRequest editTipoPropiedad)
        {
            try
            {
                var tipoPropiedad = await _tipoPropiedadRepository.UpdateTipoPropiedad(editTipoPropiedad);

                return tipoPropiedad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TipoPropiedadCreateRequest> CreateTipoPropiedad(TipoPropiedadCreateRequest newTipoPropiedad)
        {
            try
            {
                var tipoPropiedad = await _tipoPropiedadRepository.CreateTipoPropiedad(newTipoPropiedad);

                return tipoPropiedad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeleteTipoPropiedad(int id)
        {
            try
            {
                var response = _tipoPropiedadRepository.DeleteTipoPropiedad(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
