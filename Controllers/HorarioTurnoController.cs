using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorarioTurnoController : ControllerBase
    {
        private readonly IHorarioTurnoService _service;
        private readonly ILogger<HorarioTurnoController> _logger;

        public HorarioTurnoController(IHorarioTurnoService service, ILogger<HorarioTurnoController> logger)
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
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Horarios obtenidos exitosamente",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener horarios de turno");
                return StatusCode(500, new ApiResponse<string>{Success = false, Message = ex.Message, Data = null});
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var data = await _service.GetByIdAsync(id);
                if (data == null)
                    return NotFound(new ApiResponse<string> { Success = false, Message = "Horario no encontrado", Data = null });
                return Ok(new ApiResponse<HorarioTurnoModel> { Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener horario {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] HorarioTurnoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                var rows = await _service.CreateAsync(model);
                return Ok(new ApiResponse<string>{ Success = true, Message = "Horario creado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear horario");
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] HorarioTurnoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                model.Id_Turno = id;
                var rows = await _service.UpdateAsync(model);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Horario no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Horario actualizado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar horario {Id}", id);
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
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Horario no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Horario eliminado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar horario {Id}", id);
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
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Horario no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Estado actualizado", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cambiar estado horario {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}
