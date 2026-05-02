using Condominio.DTOs.Request;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaEspacioController : ControllerBase
    {
        private readonly IReservaEspacioService _svc;
        public ReservaEspacioController(IReservaEspacioService svc) => _svc = svc;

        [HttpGet("get-all")] public async Task<IActionResult> GetAll() { try { return Ok(await _svc.GetAllAsync()); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
        [HttpGet("get-by-espacio/{id}")] public async Task<IActionResult> GetByEspacio(int id) { try { return Ok(await _svc.GetByEspacio(id)); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
        [HttpGet("get-by-residente/{id}")] public async Task<IActionResult> GetByResidente(int id) { try { return Ok(await _svc.GetByResidente(id)); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
        [HttpPost("create")] public async Task<IActionResult> Create([FromBody] ReservaEspacioCreateRequest req) { try { return Ok(await _svc.Create(req)); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
        [HttpPut("update/{id}")] public async Task<IActionResult> Update([FromBody] ReservaEspacioUpdateRequest req) { try { return Ok(await _svc.Update(req)); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
        [HttpPatch("estado/{id}")] public async Task<IActionResult> Estado(int id, [FromQuery] string estado, [FromQuery] int? aprobadoPor) { try { return Ok(await _svc.CambiarEstado(id, estado, aprobadoPor)); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
    }

}
