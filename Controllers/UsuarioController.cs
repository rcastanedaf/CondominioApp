using Condominio.DTOs.Request;
using Condominio.DTOs.Response;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _svc;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioService svc, ILogger<UsuarioController> logger)
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
                    Message = "Usuarios obtenidos exitosamente",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener usuarios");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateRequest req, string passwordHash, string salt)
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
                var result = await _svc.Create(req, passwordHash, salt);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Usuario creado exitosamente",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateRequest req)
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
                    Message = "Usuario actualizado exitosamente",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar usuario con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPatch("cambiar-password")]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordRequest req, string newHash, string salt)
        {
            if (req == null || req.Id_Usuario <= 0)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "El ID del usuario es inválido",
                    Data = null
                });
            }

            try
            {
                var result = await _svc.CambiarPassword(req.Id_Usuario, newHash, salt);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Contraseña cambiada exitosamente",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al cambiar contraseña del usuario: {req.Id_Usuario}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPatch("desbloquear/{id}")]
        public async Task<IActionResult> Desbloquear(int id)
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
                var result = await _svc.Desbloquear(id);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Usuario desbloqueado exitosamente",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al desbloquear usuario con ID: {id}");
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] DTOs.Request.LoginRequest req)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Credenciales inválidas",
                    Data = errors
                });
            }

            try
            {
                var result = await _svc.Login(req.Username, req.Password);
                return Ok(new ApiResponse<object>
                {
                    Success = true,
                    Message = "Login exitoso",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al hacer login con usuario: {req.Username}");
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
