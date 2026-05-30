using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("Factura")]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _service;
        private readonly ILogger<FacturaController> _logger;

        public FacturaController(IFacturaService service, ILogger<FacturaController> logger)
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
                _logger.LogError(ex, "Error al obtener todas las facturas");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurri� un error interno en el servidor." });
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
                _logger.LogError(ex, "Error al obtener la factura por id {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurri� un error interno en el servidor." });
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
                _logger.LogError(ex, "Error al obtener facturas por propiedad {IdPropiedad}", idPropiedad);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurri� un error interno en el servidor." });
            }
        }

        [HttpGet("get-next-correlative")]
        public async Task<IActionResult> GetNextCorrelative()
        {
            try
            {
                var nextCorrelative = await _service.GetNextCorrelativeAsync();
                return Ok(new { nextCorrelative });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el siguiente correlativo");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurri� un error interno en el servidor." });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] FacturaModel model)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(model.NumeroFactura))
                    return BadRequest(new { message = "El número de factura es requerido" });
                if (string.IsNullOrWhiteSpace(model.ReceptorNombre))
                    return BadRequest(new { message = "El nombre del receptor es requerido" });
                if (string.IsNullOrWhiteSpace(model.ReceptorNit))
                    return BadRequest(new { message = "El NIT del receptor es requerido" });
                if (!model.IdPropiedad.HasValue || model.IdPropiedad <= 0)
                    return BadRequest(new { message = "La propiedad es requerida" });
                if (!model.IdCorrelativo.HasValue || model.IdCorrelativo <= 0)
                    return BadRequest(new { message = "El correlativo es requerido" });

                _logger.LogInformation($"Creando factura: {System.Text.Json.JsonSerializer.Serialize(model)}");
                var idFactura = await _service.CreateAsync(model);
                return Ok(new { message = "Factura creada exitosamente", idFactura });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la factura: {Message}\n{StackTrace}", ex.Message, ex.StackTrace);
                
                // Mensajes más específicos según el tipo de error (Oracle ORA- codes)
                string errorMessage = "Error al crear la factura";
                string msgLower = ex.Message.ToLower();
                if (msgLower.Contains("unique constraint") || msgLower.Contains("ora-00001"))
                    errorMessage = "El número de factura ya existe en el sistema";
                else if (msgLower.Contains("integrity constraint") || msgLower.Contains("ora-02291") || msgLower.Contains("parent key not found"))
                    errorMessage = "Una o más referencias (propiedad, residente, moneda, etc.) no son válidas";
                else if (msgLower.Contains("cannot insert null") || msgLower.Contains("ora-01400"))
                    errorMessage = "Faltan campos obligatorios en la factura";
                else if (msgLower.Contains("check constraint") || msgLower.Contains("ora-02290"))
                    errorMessage = "Un valor no cumple las restricciones del sistema";

                return StatusCode(StatusCodes.Status500InternalServerError, new { 
                    message = errorMessage,
                    error = ex.Message,
                    details = ex.InnerException?.Message
                });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] FacturaModel model)
        {
            try
            {
                await _service.UpdateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la factura");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurri� un error interno en el servidor." });
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
                _logger.LogError(ex, "Error al eliminar la factura {Id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocurri� un error interno en el servidor." });
            }
        }
    }
}
