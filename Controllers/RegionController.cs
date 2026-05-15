using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _service;
        private readonly ILogger<RegionController> _logger;

        public RegionController(IRegionService service, ILogger<RegionController> logger)
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
                return Ok(new ApiResponse<IEnumerable<RegionModel>> { Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener regiones");
                return StatusCode(500, new ApiResponse<string> { Success = false, Message = ex.Message, Data =null });
            }
        }

        [HttpGet("get-by-pais/{idPais}")]
        public async Task<IActionResult> GetByPais([FromRoute] int idPais)
        {
            try
            {
                var data = await _service.GetByPaisAsync(idPais);
                return Ok(new ApiResponse<IEnumerable<RegionModel>>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener regiones del país {Id}", idPais);
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
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Región no encontrada", Data = null });
                return Ok(new ApiResponse<RegionModel>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener región {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                await _service.CreateAsync(model);
                return Ok(new ApiResponse<string>{ Success = true, Message = "Región creada correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear región");
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RegionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                model.IdRegion = id;
                var rows = await _service.UpdateAsync(model);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Región no encontrada", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Región actualizada correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar región {Id}", id);
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
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Región no encontrada", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Región eliminada correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar región {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}