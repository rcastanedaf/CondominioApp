using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcuerdoPagoController : ControllerBase
    {
        private readonly IAcuerdoPagoService _service;
        private readonly ILogger<AcuerdoPagoController> _logger;

        public AcuerdoPagoController(IAcuerdoPagoService service, ILogger<AcuerdoPagoController> logger)
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
                return Ok(new ApiResponse<IEnumerable<AcuerdoPagoModel>> { Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener acuerdos de pago");
                return StatusCode(500, new ApiResponse<string> { Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpGet("get-by-residente/{idResidente}")]
        public async Task<IActionResult> GetByResidente([FromRoute] int idResidente)
        {
            try
            {
                var data = await _service.GetByResidenteAsync(idResidente);
                return Ok(new ApiResponse<IEnumerable<AcuerdoPagoModel>>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener acuerdos del residente {Id}", idResidente);
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
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Acuerdo no encontrado", Data = null });
                return Ok(new ApiResponse<AcuerdoPagoModel>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener acuerdo {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpGet("get-cuotas/{idAcuerdo}")]
        public async Task<IActionResult> GetCuotas([FromRoute] int idAcuerdo)
        {
            try
            {
                var data = await _service.GetCuotasAsync(idAcuerdo);
                return Ok(new ApiResponse<IEnumerable<CuotaAcuerdoModel>>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener cuotas del acuerdo {Id}", idAcuerdo);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AcuerdoPagoCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                await _service.CreateAsync(request);
                return Ok(new ApiResponse<string>{ Success = true, Message = "Acuerdo de pago creado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear acuerdo de pago");
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AcuerdoPagoUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                var rows = await _service.UpdateAsync(id, request);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Acuerdo no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Acuerdo actualizado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar acuerdo {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPatch("pagar-cuota/{idCuota}")]
        public async Task<IActionResult> PagarCuota([FromRoute] int idCuota)
        {
            try
            {
                var rows = await _service.PagarCuotaAsync(idCuota);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Cuota no encontrada", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Cuota marcada como pagada", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al pagar cuota {Id}", idCuota);
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
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Acuerdo no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Acuerdo eliminado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar acuerdo {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null }    );
            }
        }
    }
}