using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("SeguimientoIncidencia")]
    public class SeguimientoIncidenciaController : ControllerBase
    {
        private readonly ISeguimientoIncidenciaService _service;
        private readonly ILogger<SeguimientoIncidenciaController> _logger;

        public SeguimientoIncidenciaController(ISeguimientoIncidenciaService service, ILogger<SeguimientoIncidenciaController> logger)
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
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los seguimientos de incidencia");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpGet("get-by-incidencia")]
        public async Task<IActionResult> GetByIncidencia(int idIncidencia) // ✅ antes era "id"
        {
            var data = await _service.GetByIncidenciaAsync(idIncidencia);
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SeguimientoIncidenciaModel model)
        {
            try
            {
                await _service.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el seguimiento de incidencia");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SeguimientoIncidenciaModel model)
        {
            try
            {
                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el seguimiento de incidencia");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el seguimiento de incidencia {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }
    }
}