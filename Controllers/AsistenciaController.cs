using Condominio.DTOs.Request;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsistenciaController : ControllerBase
    {
        private readonly IAsistenciaService _svc;
        public AsistenciaController(IAsistenciaService svc) => _svc = svc;
        [HttpGet("get-by-empleado/{id}")] 
        public async Task<IActionResult> GetByEmpleado(int id) {
            try { 
                return Ok(await _svc.GetByEmpleado(id)); 
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message }); 
            }
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AsistenciaCreateRequest req) {
            try { return Ok(await _svc.Create(req)); 
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message });
            } 
        }
        [HttpPatch("salida/{id}")]
        public async Task<IActionResult> RegistrarSalida(int id) { 
            try {
                return Ok(await _svc.RegistrarSalida(id)); 
            } catch (Exception ex) { 
                return BadRequest(new { message = ex.Message }); 
            } 
        }
    }
}
