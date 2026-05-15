using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoMonedaController : ControllerBase
    {
        private readonly ITipoMonedaService _tipoMonedaService;
        private readonly ILogger<TipoMonedaController> _logger;

        public TipoMonedaController(ITipoMonedaService tipoMonedaService, ILogger<TipoMonedaController> logger)
        {
            _tipoMonedaService = tipoMonedaService;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-all-tipo-moneda")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _tipoMonedaService.GetAllAsync();

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Tipos de moneda obtenidos exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener tipos de moneda");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("create-tipo-moneda")]
        public async Task<IActionResult> Create([FromBody] TipoMonedaCreateRequest request)
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

            try
            {
                var response = await _tipoMonedaService.CreateAsync(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Tipo de moneda creado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear tipo de moneda");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut]
        [Route("update-tipo-moneda/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TipoMonedaModel request)
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
                var response = await _tipoMonedaService.UpdateAsync(request, id);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Tipo de moneda actualizado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar tipo de moneda");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete]
        [Route("delete-tipo-moneda/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
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
                var response = await _tipoMonedaService.DeleteAsync(id);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Tipo de moneda eliminado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar tipo de moneda");
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

