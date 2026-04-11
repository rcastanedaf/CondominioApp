using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("CicloFacturacion")]
    public class CicloFacturacionController : ControllerBase
    {
        private readonly ICicloFacturacionService _service;
        private readonly ILogger<CicloFacturacionController> _logger;

        public CicloFacturacionController(ICicloFacturacionService service, ILogger<CicloFacturacionController> logger)
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
                _logger.LogError(ex, "Error al obtener todos los ciclos de facturación");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await _service.GetByIdAsync(id);
                if (data == null) return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el ciclo de facturación por id {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpGet("get-by-propiedad/{idPropiedad}")]
        public async Task<IActionResult> GetByPropiedad(int idPropiedad)
        {
            try
            {
                var data = await _service.GetByPropiedadAsync(idPropiedad);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener ciclos de facturación por propiedad {IdPropiedad}", idPropiedad);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CicloFacturacionModel model)
        {
            try
            {
                await _service.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el ciclo de facturación");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CicloFacturacionModel model)
        {
            try
            {
                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el ciclo de facturación");
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
                _logger.LogError(ex, "Error al eliminar el ciclo de facturación {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }
    }
}
