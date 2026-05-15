using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetodoPagoController : ControllerBase
    {
        private readonly IMetodoPagoService _metodoPagoService;
        private readonly ILogger<MetodoPagoController> _logger;

        public MetodoPagoController(IMetodoPagoService metodoPagoService, ILogger<MetodoPagoController> logger)
        {
            _metodoPagoService = metodoPagoService;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-all-metodo-pago")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _metodoPagoService.GetAllAsync();

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Métodos de pago obtenidos exitosamente",
                    Data = response
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al obtener métodos de pago");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("create-metodo-pago")]
        public async Task<IActionResult> Create([FromBody] MetodoPagoCreateRequest request)
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
                var response = await _metodoPagoService.CreateAsync(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Método de pago creado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear método de pago");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut]
        [Route("update-metodo-pago/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MetodoPagoModel request)
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
                var response = await _metodoPagoService.UpdateAsync(request, id);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Método de pago actualizado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar método de pago");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete]
        [Route("delete-metodo-pago/{id}")]
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
                var response = await _metodoPagoService.DeleteAsync(id);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Método de pago eliminado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar método de pago");
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

