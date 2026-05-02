using Condominio.DTOs.Request;
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
        public UsuarioController(IUsuarioService svc) => _svc = svc;

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll() { 
            try { return Ok(await _svc.GetAllAsync()); 
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message }); 
            } 
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateRequest req, string passwordHash, string salt) {
            try { return Ok(await _svc.Create(req, passwordHash, salt)); 
            } catch (Exception ex) { 
                return BadRequest(new { message = ex.Message }); 
            } 
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UsuarioUpdateRequest req) {
            try { return Ok(await _svc.Update(req)); 
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message }); 
            } 
        }

        [HttpPatch("cambiar-password")]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordRequest req, string newHash, string salt) {
            try { 
                return Ok(await _svc.CambiarPassword(req.Id_Usuario, newHash, salt));
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message }); 
            } 
        }

        [HttpPatch("desbloquear/{id}")]
        public async Task<IActionResult> Desbloquear(int id) {
            try { return Ok(await _svc.Desbloquear(id)); 
            } catch (Exception ex) { 
                return BadRequest(new { message = ex.Message }); 
            } 
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] DTOs.Request.LoginRequest req)
        {
            try { return Ok(await _svc.Login(req.Username, req.Password)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

    }
}
