using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("Incidencia")]
    public class IncidenciaController : ControllerBase
    {
        private readonly IIncidenciaService _service;
        private readonly ILogger<IncidenciaController> _logger;

        public IncidenciaController(IIncidenciaService service, ILogger<IncidenciaController> logger)
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
                _logger.LogError(ex, "Error al obtener todas las incidencias");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] IncidenciaModel model)
        {
            try
            {
                // Validación manual
                if (model == null)
                    return BadRequest(new { message = "El modelo está vacío" });

                if (string.IsNullOrWhiteSpace(model.Titulo))
                    return BadRequest(new { message = "El título es requerido" });

                if (model.IdReportadoPor <= 0)
                    return BadRequest(new { message = "ID Reportado Por es requerido" });

                // Log detallado
                _logger.LogInformation("=== INTENTANDO CREAR INCIDENCIA ===");
                _logger.LogInformation($"Título: {model.Titulo}");
                _logger.LogInformation($"IdReportadoPor: {model.IdReportadoPor}");
                _logger.LogInformation($"IdPropiedad: {model.IdPropiedad}");
                _logger.LogInformation($"Prioridad: {model.Prioridad}");

                await _service.CreateAsync(model);
                return Ok(new { success = true, message = "Incidencia creada exitosamente" });
            }
            catch (OracleException ex)
            {
                _logger.LogError(ex, "Error de Oracle al crear incidencia");
                return StatusCode(500, new
                {
                    message = "Error de base de datos",
                    oracleError = ex.Message,
                    oracleCode = ex.ErrorCode
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error general al crear incidencia");
                return StatusCode(500, new
                {
                    message = "Error interno",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace?.Substring(0, 500) // Primeros 500 caracteres
                });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] IncidenciaModel model)
        {
            try
            {
                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la incidencia");
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
                _logger.LogError(ex, "Error al eliminar la incidencia {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }
    }
}