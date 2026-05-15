using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaService _svc;
        private readonly ILogger<AsistenciaController> _logger;

        public AsistenciaController(IAsistenciaService svc, ILogger<AsistenciaController> logger)
        {
            _svc = svc;
            _logger = logger;
        }

        [HttpGet("get-by-empleado/{id}")]
        public async Task<IActionResult> GetByEmpleado([FromRoute] int id)
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
                var response = await _svc.GetByEmpleado(id);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Asistencias del empleado obtenidas exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener asistencias por empleado");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AsistenciaCreateRequest req)
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
                    Message = "Asistencia registrada exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear asistencia");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPatch("salida/{id}")]
        public async Task<IActionResult> RegistrarSalida([FromRoute] int id)
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
                var response = await _svc.RegistrarSalida(id);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Salida registrada exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar salida");
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

