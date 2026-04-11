using Condominio.DTOs.Request;
using Condominio.Models;

namespace Condominio.Repositories.Interfaces
{
    public interface IPersonaRepository
    {
        public Task<List<Persona>> GetAllAsync();
        public Task<List<Persona>> GetId(int id);
        public Task<List<Persona>> GetNombre(string nombre);
        public Task<PersonaCreateRequest> CreatePersona(PersonaCreateRequest newPersona);
        public Task<PersonaUpdateRequest> UpdatePersona(PersonaUpdateRequest editPersona);
        public Task<bool> DeletePersona(int id);
    }
}
