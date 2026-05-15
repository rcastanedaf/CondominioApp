using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GravamenPropiedadController : ControllerBase
    {
        private readonly IgravamenPropiedadService _service;
        private readonly ILogger<GravamenPropiedadController> _logger;

        public GravamenPropiedadController(IgravamenPropiedadService service, ILogger<GravamenPropiedadController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAll();
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Gravámenes de propiedad obtenidos exitosamente",
                    Data = data
                });
            }
            catch (OracleException ex)
            {
                _logger.LogError(ex, "Error Oracle al obtener gravámenes");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener gravámenes");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] gravamenPropiedadRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            try
            {
                var result = await _service.Create(request);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Gravamen de propiedad creado exitosamente",
                    Data = result
                });
            }
            catch (OracleException ex)
            {
                _logger.LogError(ex, "Error Oracle al crear gravamen");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear gravamen");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] gravamenPropiedadModel request)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser válido",
                    Data = null
                });

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            try
            {
                var result = await _service.Update(request, id);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Gravamen de propiedad actualizado exitosamente",
                    Data = result
                });
            }
            catch (OracleException ex)
            {
                _logger.LogError(ex, "Error Oracle al actualizar gravamen");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar gravamen");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser válido",
                    Data = null
                });

            try
            {
                await _service.Delete(id);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Gravamen de propiedad eliminado exitosamente",
                    Data = null
                });
            }
            catch (OracleException ex)
            {
                _logger.LogError(ex, "Error Oracle al eliminar gravamen");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar gravamen");
                return StatusCode(500, new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
    }
}
