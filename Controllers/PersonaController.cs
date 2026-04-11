using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }


        [HttpGet]
        [Route("get-all-persona")]
        public async Task<IActionResult> Get()
        {
            var response = new List<Persona>();

            try
            {
                response = await _personaService.GetAllAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-id-persona")]
        public async Task<IActionResult> GetId([FromBody] int id)
        {
            var response = new List<Persona>();

            try
            {
                response = await _personaService.GetId(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-nombre-persona")]
        public async Task<IActionResult> GetNombre([FromBody] string nombre)
        {
            var response = new List<Persona>();

            try
            {
                response = await _personaService.GetNombre(nombre);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create-persona")]
        public async Task<IActionResult> CreatePersona([FromBody] PersonaCreateRequest request)
        {
            try
            {
                var response = await _personaService.CreatePersona(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-persona/{id}")]
        public async Task<IActionResult> UpdatePersona(int id, [FromBody] PersonaUpdateRequest request)
        {
            try
            {
                request.Id_Persona = id;  // ✅ asignar el id de la ruta al request
                var response = await _personaService.UpdatePersona(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete-persona/{id}")]
        public async Task<IActionResult> DeletePersona([FromRoute] int id)
        {
            try
            {
                var response = await _personaService.DeletePersona(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); ;
            }
        }
    }
}
