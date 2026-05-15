using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliarResidenteController : ControllerBase
    {
        private readonly IFamiliarResidenteService _service;
        private readonly ILogger<FamiliarResidenteController> _logger;

        public FamiliarResidenteController(IFamiliarResidenteService service, ILogger<FamiliarResidenteController> logger)
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
                return Ok(new ApiResponse<IEnumerable<FamiliarResidenteModel>> { Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener familiares");
                return StatusCode(500, new ApiResponse<string> { Success = false, Message =  ex.Message, Data  = null });
            }
        }

        [HttpGet("get-by-residente/{idResidente}")]
        public async Task<IActionResult> GetByResidente([FromRoute] int idResidente)
        {
            try
            {
                var data = await _service.GetByResidenteAsync(idResidente);
                return Ok(new ApiResponse<IEnumerable<FamiliarResidenteModel>>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener familiares del residente {Id}", idResidente);
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
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Familiar no encontrado", Data = null });
                return Ok(new ApiResponse<FamiliarResidenteModel>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener familiar {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] FamiliarResidenteCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                await _service.CreateAsync(request);
                return Ok(new ApiResponse<string>{ Success = true, Message = "Familiar registrado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear familiar");
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] FamiliarResidenteUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                var rows = await _service.UpdateAsync(id, request);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Familiar no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Familiar actualizado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar familiar {Id}", id);
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
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Familiar no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Familiar eliminado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar familiar {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPatch("toggle-activo/{id}")]
        public async Task<IActionResult> ToggleActivo([FromRoute] int id, [FromQuery] int activo)
        {
            try
            {
                var rows = await _service.ToggleActivoAsync(id, activo);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Familiar no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Estado actualizado", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cambiar estado familiar {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}