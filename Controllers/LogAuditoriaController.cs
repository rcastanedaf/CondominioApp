using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogAuditoriaController : ControllerBase
    {
        private readonly ILogAuditoriaService _svc;
        public LogAuditoriaController(ILogAuditoriaService svc) => _svc = svc;

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int top = 500) {
            try { return Ok(await _svc.GetAllAsync(top)); 
            } catch (Exception ex) { 
                return BadRequest(new { message = ex.Message }); 
            } 
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] LogAuditoriaCreateRequest req) { 
            try { 
                await _svc.Registrar(req); return Ok(new { ok = true });
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message }); 
            } 
        }

    }
}
