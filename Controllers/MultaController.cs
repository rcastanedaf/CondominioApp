using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MultaController : ControllerBase
    {
        private readonly IMultaService _multaService;
        private readonly ILogger<MultaController> _logger;

        public MultaController(IMultaService multaService, ILogger<MultaController> logger)
        {
            _multaService = multaService;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-all-multa")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _multaService.GetAllAsync();

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Multas obtenidas exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las multas");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("get-id-multa/{id}")]
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
                var response = await _multaService.GetId(id);

                if (response == null || response.Count == 0)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Multa no encontrada",
                        Data = null
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Multa obtenida exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener multa por ID");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("create-multa")]
        public async Task<IActionResult> CreateMulta([FromBody] MultaCreateRequest request)
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

            if (request.Fecha_Vencimiento < request.Fecha_Infraccion)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "La fecha de vencimiento no puede ser anterior a la fecha de infracción",
                    Data = null
                });
            }

            try
            {
                var response = await _multaService.CreateMulta(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Multa creada exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear multa");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut]
        [Route("update-multa/{id}")]
        public async Task<IActionResult> UpdateMulta([FromRoute] int id, [FromBody] MultaUpdateRequest request)
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

            if (request.Fecha_Vencimiento < request.Fecha_Infraccion)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "La fecha de vencimiento no puede ser anterior a la fecha de infracción",
                    Data = null
                });
            }

            try
            {
                var response = await _multaService.UpdateMulta(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Multa actualizada exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar multa");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete]
        [Route("delete-multa/{id}")]
        public async Task<IActionResult> DeleteMulta([FromRoute] int id)
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
                var response = await _multaService.DeleteMulta(id);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Multa eliminada exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar multa");
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
