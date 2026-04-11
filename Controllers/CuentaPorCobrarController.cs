using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("CuentaPorCobrar")]
    public class CuentaPorCobrarController : ControllerBase
    {
        private readonly ICuentaPorCobrarService _service;
        private readonly ILogger<CuentaPorCobrarController> _logger;

        public CuentaPorCobrarController(ICuentaPorCobrarService service, ILogger<CuentaPorCobrarController> logger)
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
                _logger.LogError(ex, "Error al obtener todas las cuentas por cobrar");
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
                _logger.LogError(ex, "Error al obtener la cuenta por cobrar por id {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpGet("get-by-residente/{idResidente}")]
        public async Task<IActionResult> GetByResidente(int idResidente)
        {
            try
            {
                var data = await _service.GetByResidenteAsync(idResidente);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener cuentas por cobrar del residente {IdResidente}", idResidente);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CuentaPorCobrarModel model)
        {
            try
            {
                await _service.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la cuenta por cobrar");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CuentaPorCobrarModel model)
        {
            try
            {
                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la cuenta por cobrar");
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
                _logger.LogError(ex, "Error al eliminar la cuenta por cobrar {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }
    }
}
