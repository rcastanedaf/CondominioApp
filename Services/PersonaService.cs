using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;

namespace Condominio.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaService _personaRepository;
        public PersonaService(IPersonaService personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<List<Persona>> GetAllAsync()
        {
            try
            {
                var allPersona = await _personaRepository.GetAllAsync();

                return allPersona;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Persona>> GetId(int id)
        {
            try
            {
                var idPersona = await _personaRepository.GetId(id);

                return idPersona;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Persona>> GetNombre(string nombre)
        {
            try
            {
                var nombrePersona = await _personaRepository.GetNombre(nombre);

                return nombrePersona;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonaUpdateRequest> UpdatePersona(PersonaUpdateRequest editPersona)
        {
            try
            {
                var persona = await _personaRepository.UpdatePersona(editPersona);

                return persona;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PersonaCreateRequest> CreatePersona(PersonaCreateRequest newPersona)
        {
            try
            {
                var persona = await _personaRepository.CreatePersona(newPersona);

                return persona;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> DeletePersona(int id)
        {
            try
            {
                var response = _personaRepository.DeletePersona(id);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
