using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Condominio.Repositories.Interfaces;

namespace Condominio.Services
{
    public class AsistenciaService : IAsistenciaService
    {
        private readonly IAsistenciaRepository _asistenciaRepository;
        public AsistenciaService(IAsistenciaRepository asistenciaRepository)
        {
            _asistenciaRepository = asistenciaRepository;
        }

        public async Task<List<AsistenciaModel>> GetByEmpleado(int id)
        {
            try { 
           
                var allAsistencias = await _asistenciaRepository.GetByEmpleado(id);

                return allAsistencias;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AsistenciaCreateRequest> Create(AsistenciaCreateRequest r)
        {
            try
            {
                var asistencia = await _asistenciaRepository.Create(r);

                return asistencia;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> RegistrarSalida(int id)
        {
            try
            {
                var response = _asistenciaRepository.RegistrarSalida(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
