using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _svc;
        private readonly ILogger<ProveedorController> _logger;

        public ProveedorController(IProveedorService svc, ILogger<ProveedorController> logger)
        {
            _svc = svc;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _svc.GetAllAsync();
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Proveedores obtenidos exitosamente",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener proveedores");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProveedorCreateRequest req)
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
                var result = await _svc.Create(req);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Proveedor creado exitosamente",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear proveedor");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProveedorUpdateRequest req)
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
                var result = await _svc.Update(req);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Proveedor actualizado exitosamente",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar proveedor con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
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
                var result = await _svc.Delete(id);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Proveedor eliminado exitosamente",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar proveedor con ID: {id}");
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
