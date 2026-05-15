using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
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
        private readonly ILogger<PersonaController> _logger;

        public PersonaController(IPersonaService personaService, ILogger<PersonaController> logger)
        {
            _personaService = personaService;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-all-persona")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _personaService.GetAllAsync();

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Personas obtenidas exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las personas");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("get-id-persona/{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID de la persona debe ser un número válido mayor a 0",
                    Data = null
                });
            }

            try
            {
                var response = await _personaService.GetId(id);

                if (response == null || response.Count == 0)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Persona no encontrada",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Persona obtenida exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener persona con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("get-nombre-persona/{nombre}")]
        public async Task<IActionResult> GetNombre([FromRoute] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El nombre no puede estar vacío",
                    Data = null
                });
            }

            try
            {
                var response = await _personaService.GetNombre(nombre);

                if (response == null || response.Count == 0)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "No se encontraron personas con ese nombre",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Personas obtenidas exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener personas por nombre: {nombre}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("create-persona")]
        public async Task<IActionResult> CreatePersona([FromBody] PersonaCreateRequest request)
        {
            // Validar ModelState
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            try
            {
                var response = await _personaService.CreatePersona(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Persona creada exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear persona");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut]
        [Route("update-persona/{id}")]
        public async Task<IActionResult> UpdatePersona(int id, [FromBody] PersonaUpdateRequest request)
        {
            // Validar ID
            if (id <= 0)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });
            }

            // Validar ModelState
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            try
            {
                request.Id_Persona = id;
                var response = await _personaService.UpdatePersona(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Persona actualizada exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar persona con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete]
        [Route("delete-persona/{id}")]
        public async Task<IActionResult> DeletePersona([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });
            }

            try
            {
                var response = await _personaService.DeletePersona(id);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Persona eliminada exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar persona con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
    }
}
