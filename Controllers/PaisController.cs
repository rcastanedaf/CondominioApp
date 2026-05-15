using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _service;
        private readonly ILogger<PaisController> _logger;

        public PaisController(IPaisService service, ILogger<PaisController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("get-all-pais")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAll();
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Países obtenidos exitosamente",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener países");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });

            try
            {
                var data = await _service.GetById(id);
                if (data == null)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "País no encontrado",
                        Data = null
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "País obtenido exitosamente",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener país con ID {Id}", id);
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("create-pais")]
        public async Task<IActionResult> Create([FromBody] PaisRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            // Normalizar código a mayúsculas
            var codigoNorm = request.Codigo.Trim().ToUpper();

            try
            {
                var rows = await _service.Create(request);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "País creado exitosamente",
                    Data = rows
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear país");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut("update-pais/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PaisRequest request)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            // Normalizar código a mayúsculas
            var codigoNorm = request.Codigo.Trim().ToUpper();

            try
            {
                var rows = await _service.Update(id, request);
                if (rows == 0)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "País no encontrado",
                        Data = null
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "País actualizado exitosamente",
                    Data = rows
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar país con ID {Id}", id);
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete("delete-pais/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });

            try
            {
                var result = await _service.Delete(id);
                if (!result)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "País no encontrado",
                        Data = null
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "País eliminado exitosamente",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar país con ID {Id}", id);
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