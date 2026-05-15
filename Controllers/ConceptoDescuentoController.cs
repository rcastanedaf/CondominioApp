using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConceptoDescuentoController : ControllerBase
    {
        private readonly IConceptoDescuentoService _conceptoDescuentoService;
        private readonly ILogger<ConceptoDescuentoController> _logger;

        public ConceptoDescuentoController(IConceptoDescuentoService conceptoDescuentoService, ILogger<ConceptoDescuentoController> logger)
        {
            _conceptoDescuentoService = conceptoDescuentoService;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-all-ConceptoDesc")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _conceptoDescuentoService.GetAllAsync();

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Conceptos de descuento obtenidos exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener conceptos de descuento");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("get-id-ConceptoDesc/{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });
            }

            try
            {
                var response = await _conceptoDescuentoService.GetId(id);

                if (response == null || response.Count == 0)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Concepto de descuento no encontrado",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Concepto de descuento obtenido exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener concepto de descuento con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("get-nombre-ConceptoDesc/{nombre}")]
        public async Task<IActionResult> GetNombre([FromRoute] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El nombre no puede estar vacío",
                    Data = null
                });
            }

            try
            {
                var response = await _conceptoDescuentoService.GetNombre(nombre);

                if (response == null || response.Count == 0)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "No se encontraron conceptos de descuento con ese nombre",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Conceptos de descuento obtenidos exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener conceptos de descuento por nombre: {nombre}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("create-ConceptoDesc")]
        public async Task<IActionResult> CreateConceptoDesc([FromBody] ConceptoDescuentoCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            try
            {
                var response = await _conceptoDescuentoService.CreateConceptoDescuento(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Concepto de descuento creado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear concepto de descuento");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut]
        [Route("update-ConceptoDesc/{id}")]
        public async Task<IActionResult> UpdateConceptoDes(int id, [FromBody] ConceptoDescuentoUpdateRequest request)
        {
            if (id <= 0)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Error en los datos enviados",
                    Data = errors
                });
            }

            try
            {
                var response = await _conceptoDescuentoService.UpdateConceptoDescuento(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Concepto de descuento actualizado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar concepto de descuento con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete]
        [Route("delete-ConceptoDesc/{id}")]
        public async Task<IActionResult> DeleteConceptoDesc([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });
            }

            try
            {
                var response = await _conceptoDescuentoService.DeleteConceptoDescuento(id);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Concepto de descuento eliminado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar concepto de descuento con ID: {id}");
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
