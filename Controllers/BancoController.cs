using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;
        private readonly ILogger<BancoController> _logger;

        public BancoController(IBancoService bancoService, ILogger<BancoController> logger)
        {
            _bancoService = bancoService;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-all-banco")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _bancoService.GetAllAsync();

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Bancos obtenidos exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los bancos");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("get-id-banco/{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID del banco debe ser un número válido mayor a 0",
                    Data = null
                });
            }

            try
            {
                var response = await _bancoService.GetId(id);

                if (response == null || response.Count == 0)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Banco no encontrado",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Banco obtenido exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener banco con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("get-nombre-banco/{nombre}")]
        public async Task<IActionResult> GetNombre([FromRoute] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El nombre del banco no puede estar vacío",
                    Data = null
                });
            }

            try
            {
                var response = await _bancoService.GetNombre(nombre);

                if (response == null || response.Count == 0)
                {
                    return NotFound(new ApiResponse<object>
                    {
                        Success = false,
                        Message = "No se encontraron bancos con ese nombre",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Bancos obtenidos exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener bancos por nombre: {nombre}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost]
        [Route("create-banco")]
        public async Task<IActionResult> CreateBanco([FromBody] BancoCreateRequest request)
        {
            // Validar ModelState
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
                var response = await _bancoService.CreateBanco(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Banco creado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear banco");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut]
        [Route("update-banco/{id}")]
        public async Task<IActionResult> UpdateBanco(int id, [FromBody] BancoUpdateRequest request)
        {
            // Validar ID
            if (id <= 0)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID debe ser un número válido mayor a 0",
                    Data = null
                });
            }

            // Validar ModelState
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
                request.Id = id;
                var response = await _bancoService.UpdateBanco(request);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Banco actualizado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar banco con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete]
        [Route("delete-banco/{id}")]
        public async Task<IActionResult> DeleteBanco([FromRoute] int id)
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
                var response = await _bancoService.DeleteBanco(id);

                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Banco eliminado exitosamente",
                    Data = response
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar banco con ID: {id}");
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
