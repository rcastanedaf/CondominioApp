using Condominio.DTOs.Request;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _svc;
        public EmpleadoController(IEmpleadoService svc) => _svc = svc;
        [HttpGet("get-all")] 
        public async Task<IActionResult> GetAll() { 
            try { 
                return Ok(await _svc.GetAllAsync()); 
            } catch 
            (Exception ex) { 
                return BadRequest(new { message = ex.Message }); 
            } 
        }
        [HttpPost("create")] 
        public async Task<IActionResult> Create([FromBody] EmpleadoCreateRequest req) { 
            try { 
                return Ok(await _svc.Create(req)); 
            } catch
            (Exception ex) {
                return BadRequest(new { message = ex.Message }); 
            } 
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] EmpleadoUpdateRequest req) { 
            try { 
                return Ok(await _svc.Update(req)); 
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message }); 
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try { 
                return Ok(await _svc.Delete(id)); 
            } catch (Exception ex) {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}
