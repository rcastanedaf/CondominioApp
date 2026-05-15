using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Repositories.Interfaces;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _service;
        private readonly IPermisoRepository _permisoRepo;
        private readonly ILogger<RolController> _logger;

        public RolController(IRolService service, IPermisoRepository permisoRepo, ILogger<RolController> logger)
        {
            _service = service;
            _permisoRepo = permisoRepo;
            _logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _service.GetAllAsync();
                return Ok(new ApiResponse<IEnumerable<RolModel>> { Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener roles");
                return StatusCode(500, new ApiResponse<string> { Success = false, Message = ex.Message,Data = null });
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var data = await _service.GetByIdAsync(id);
                if (data == null)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Rol no encontrado", Data = null });
                return Ok(new ApiResponse<RolModel>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rol {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpGet("get-permisos/{idRol}")]
        public async Task<IActionResult> GetPermisos([FromRoute] int idRol)
        {
            try
            {
                var data = await _service.GetPermisosAsync(idRol);
                return Ok(new ApiResponse<IEnumerable<PermisoModel>>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener permisos del rol {Id}", idRol);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpGet("get-all-permisos")]
        public async Task<IActionResult> GetAllPermisos()
        {
            try
            {
                var data = await _permisoRepo.GetAllAsync();
                return Ok(new ApiResponse<IEnumerable<PermisoModel>>{ Success = true, Message = "OK", Data = data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener catálogo de permisos");
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RolCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                await _service.CreateAsync(request);
                return Ok(new ApiResponse<string>{ Success = true, Message = "Rol creado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear rol");
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RolCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>{ Success = false, Message = "Datos inválidos", Data = ModelState });
            try
            {
                var rows = await _service.UpdateAsync(id, request);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Rol no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Rol actualizado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar rol {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPatch("toggle-activo/{id}")]
        public async Task<IActionResult> ToggleActivo([FromRoute] int id, [FromQuery] int activo)
        {
            try
            {
                var rows = await _service.ToggleActivoAsync(id, activo);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Rol no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Estado actualizado", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cambiar estado rol {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpPost("asignar-permiso/{idRol}/{idPermiso}")]
        public async Task<IActionResult> AsignarPermiso([FromRoute] int idRol, [FromRoute] int idPermiso)
        {
            try
            {
                await _service.AsignarPermisoAsync(idRol, idPermiso);
                return Ok(new ApiResponse<string>{ Success = true, Message = "Permiso asignado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al asignar permiso");
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpDelete("quitar-permiso/{idRol}/{idPermiso}")]
        public async Task<IActionResult> QuitarPermiso([FromRoute] int idRol, [FromRoute] int idPermiso)
        {
            try
            {
                var rows = await _service.QuitarPermisoAsync(idRol, idPermiso);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Permiso no encontrado en el rol", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Permiso removido correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al quitar permiso");
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var rows = await _service.DeleteAsync(id);
                if (rows == 0)
                    return NotFound(new ApiResponse<string>{ Success = false, Message = "Rol no encontrado", Data = null });
                return Ok(new ApiResponse<string>{ Success = true, Message = "Rol eliminado correctamente", Data = null });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar rol {Id}", id);
                return StatusCode(500, new ApiResponse<string>{ Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}