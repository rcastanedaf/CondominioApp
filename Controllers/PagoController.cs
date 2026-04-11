using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("Pago")]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _service;
        private readonly ILogger<PagoController> _logger;

        public PagoController(IPagoService service, ILogger<PagoController> logger)
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
                _logger.LogError(ex, "Error al obtener todos los pagos");
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
                _logger.LogError(ex, "Error al obtener el pago por id {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpGet("get-by-factura/{idFactura}")]
        public async Task<IActionResult> GetByFactura(int idFactura)
        {
            try
            {
                var data = await _service.GetByFacturaAsync(idFactura);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener pagos por factura {IdFactura}", idFactura);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PagoModel model)
        {
            try
            {
                await _service.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el pago");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PagoModel model)
        {
            try
            {
                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el pago");
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
                _logger.LogError(ex, "Error al eliminar el pago {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurrió un error interno en el servidor." });
            }
        }

        [HttpGet("get-by-residente/{idResidente}")]
        public async Task<IActionResult> GetByResidente(int idResidente)
        {
            var data = await _service.GetByResidenteAsync(idResidente);
            return Ok(data);
        }
    }
}
