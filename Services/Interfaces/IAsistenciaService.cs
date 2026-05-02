using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Services.Interfaces
{
    public interface IAsistenciaService
    {
        public Task<List<AsistenciaModel>> GetByEmpleado(int id);
        public Task<AsistenciaCreateRequest> Create(AsistenciaCreateRequest r);
        public Task<bool> RegistrarSalida(int id);
    }
}

