using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitaAutorizadaController : ControllerBase
    {
        private readonly IVisitaAutorizadaService _service;
        private readonly ILogger<VisitaAutorizadaController> _logger;

        public VisitaAutorizadaController(IVisitaAutorizadaService service, ILogger<VisitaAutorizadaController> logger)
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
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Visitas obtenidas exitosamente",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener visitas autorizadas");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet("get-activas")]
        public async Task<IActionResult> GetActivas()
        {
            try
            {
                var data = await _service.GetActivas();
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Visitas activas obtenidas exitosamente",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener visitas activas");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });

            try
            {
                var data = await _service.GetById(id);
                if (data == null)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Visita no encontrada",
                        Data = null
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Visita obtenida exitosamente",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener visita con ID {Id}", id);
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] VisitaAutorizadaCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            // Validar que Fecha_Hasta >= Fecha_Desde
            if (!string.IsNullOrEmpty(request.Fecha_Desde) && !string.IsNullOrEmpty(request.Fecha_Hasta))
            {
                if (DateTime.TryParse(request.Fecha_Desde, out var desde) &&
                    DateTime.TryParse(request.Fecha_Hasta, out var hasta))
                {
                    if (hasta < desde)
                        return BadRequest(new ApiResponse<object>
                        {
                            Success = false,
                            Message = "La fecha de fin no puede ser anterior a la fecha de inicio",
                            Data = null
                        });
                }
            }

            // Validar que Fecha_Desde no sea en el pasado (solo para visitas nuevas)
            if (DateTime.TryParse(request.Fecha_Desde, out var fechaDesde))
            {
                if (fechaDesde.Date < DateTime.Today)
                    return BadRequest(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "La fecha de inicio no puede ser en el pasado",
                        Data = null
                    });
            }

            try
            {
                var rows = await _service.Create(request);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Visita autorizada registrada exitosamente",
                    Data = rows
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear visita autorizada");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] VisitaAutorizadaUpdateRequest request)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            // Asignar el id de la ruta al request
            request.Id_Visita = id;

            // Validar que Fecha_Hasta >= Fecha_Desde
            if (!string.IsNullOrEmpty(request.Fecha_Desde) && !string.IsNullOrEmpty(request.Fecha_Hasta))
            {
                if (DateTime.TryParse(request.Fecha_Desde, out var desde) &&
                    DateTime.TryParse(request.Fecha_Hasta, out var hasta))
                {
                    if (hasta < desde)
                        return BadRequest(new ApiResponse<object>
                        {
                            Success = false,
                            Message = "La fecha de fin no puede ser anterior a la fecha de inicio",
                            Data = null
                        });
                }
            }

            try
            {
                var rows = await _service.Update(id, request);
                if (rows == 0)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Visita no encontrada",
                        Data = null
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Visita actualizada exitosamente",
                    Data = rows
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar visita con ID {Id}", id);
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPatch("estado/{id}")]
        public async Task<IActionResult> CambiarEstado([FromRoute] int id, [FromBody] string estado)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });

            var estadosValidos = new[] { "ACTIVA", "USADA", "VENCIDA", "CANCELADA" };
            if (string.IsNullOrWhiteSpace(estado) || !estadosValidos.Contains(estado.ToUpper()))
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Estado inválido. Use: ACTIVA, USADA, VENCIDA o CANCELADA",
                    Data = null
                });

            try
            {
                var result = await _service.CambiarEstado(id, estado.ToUpper());
                if (!result)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Visita no encontrada",
                        Data = null
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Estado actualizado exitosamente",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cambiar estado de visita con ID {Id}", id);
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });

            try
            {
                var result = await _service.Delete(id);
                if (!result)
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Visita no encontrada",
                        Data = null
                    });

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Visita eliminada exitosamente",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar visita con ID {Id}", id);
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