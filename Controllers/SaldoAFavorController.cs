using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaldoAFavorController : ControllerBase
    {
        private readonly ISaldoAFavorService _saldoAFavorService;
        private readonly ILogger<SaldoAFavorController> _logger;

        public SaldoAFavorController(ISaldoAFavorService saldoAFavorService, ILogger<SaldoAFavorController> logger)
        {
            _saldoAFavorService = saldoAFavorService;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-all-saldoAFavor")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _saldoAFavorService.GetAllAsync();

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Saldos a favor obtenidos exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener saldos a favor");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("get-id-saldoAFavor/{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser válido",
                    Data = null
                });

            try
            {
                var response = await _saldoAFavorService.GetId(id);

                if (response == null || response.Count == 0)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Saldo a favor no encontrado",
                        Data = null
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Saldo a favor obtenido exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener saldo a favor por ID");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("create-saldoAFavor")]
        public async Task<IActionResult> CreateSaldoAFavor([FromBody] SaldoAFavorCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            if (request.Monto_Disponible > request.Monto_Original)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El monto disponible no puede ser mayor al monto original",
                    Data = null
                });
            }

            if (request.Fecha_Vencimiento <= request.Fecha_Generacion)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "La fecha de vencimiento debe ser posterior a la fecha de generación",
                    Data = null
                });
            }

            try
            {
                var response = await _saldoAFavorService.CreateSaldoAFavor(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Saldo a favor creado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear saldo a favor");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut]
        [Route("update-saldoAFavor/{id}")]
        public async Task<IActionResult> UpdateSaldoAFavor([FromRoute] int id, [FromBody] SaldoAFavorUpdateRequest request)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser válido",
                    Data = null
                });

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            try
            {
                var response = await _saldoAFavorService.UpdateSaldoAFavor(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Saldo a favor actualizado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar saldo a favor");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete]
        [Route("delete-saldoAFavor/{id}")]
        public async Task<IActionResult> DeleteSaldoAFavor([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser válido",
                    Data = null
                });

            try
            {
                var response = await _saldoAFavorService.DeleteSaldoAFavor(id);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Saldo a favor eliminado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar saldo a favor");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
    }
}

