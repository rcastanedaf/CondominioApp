using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IAsistenciaRepository
    {
        public Task<List<AsistenciaModel>> GetByEmpleado(int id);
        public Task<AsistenciaCreateRequest> Create(AsistenciaCreateRequest r);
        public Task<bool> RegistrarSalida(int id);
    }
}
