using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioActivoController : ControllerBase
    {
        private readonly IServicioActivoService _service;
        private readonly ILogger<ServicioActivoController> _logger;

        public ServicioActivoController(IServicioActivoService service, ILogger<ServicioActivoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAllAsync();
                return Ok(new ApiResponse<IEnumerable<ServicioActivoModel>> { Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener servicios activos");
                return StatusCode(500, new ApiResponse<string> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpGet("get-by-propiedad/{idPropiedad}")]
        public async Task<IActionResult> GetByPropiedad([FromRoute] int idPropiedad)
        {
            try
            {
                var data = await _service.GetByPropiedadAsync(idPropiedad);
                return Ok(new ApiResponse<IEnumerable<ServicioActivoModel>>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener servicios de propiedad {Id}", idPropiedad);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var data = await _service.GetByIdAsync(id);
                if (data == null)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Servicio activo no encontrado", Data = null });
                return Ok(new ApiResponse<ServicioActivoModel>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener servicio activo {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ServicioActivoCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                await _service.CreateAsync(request);
                return Ok(new ApiResponse<string>{ Success = true, Message = "Servicio activo registrado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear servicio activo");
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ServicioActivoUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                var rows = await _service.UpdateAsync(id, request);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Servicio activo no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Servicio activo actualizado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar servicio activo {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var rows = await _service.DeleteAsync(id);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Servicio activo no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Servicio activo eliminado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar servicio activo {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}