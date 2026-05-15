using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroAccesoController : ControllerBase
    {
        private readonly IRegistroAccesoService _svc;
        private readonly ILogger<RegistroAccesoController> _logger;

        public RegistroAccesoController(IRegistroAccesoService svc, ILogger<RegistroAccesoController> logger)
        {
            _svc = svc;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int top = 200)
        {
            if (top <= 0)
                top = 200;

            try
            {
                var response = await _svc.GetAllAsync(top);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Registros de acceso obtenidos exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener registros de acceso");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet("get-by-fecha")]
        public async Task<IActionResult> GetByFecha([FromQuery] string desde, [FromQuery] string hasta)
        {
            if (string.IsNullOrWhiteSpace(desde) || string.IsNullOrWhiteSpace(hasta))
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Las fechas desde y hasta son requeridas",
                    Data = null
                });

            try
            {
                var response = await _svc.GetByFecha(desde, hasta);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Registros de acceso obtenidos exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener registros de acceso por fecha");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegistroAccesoCreateRequest req)
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
                var response = await _svc.Create(req);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Registro de acceso creado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear registro de acceso");
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

