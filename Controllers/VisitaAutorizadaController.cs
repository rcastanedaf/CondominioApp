using Condominio.DTOs.Request;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitaAutorizadaController : ControllerBase
    {
        private readonly IVisitaAutorizadaService _svc;
        public VisitaAutorizadaController(IVisitaAutorizadaService svc) => _svc = svc;

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try { return Ok(await _svc.GetAllAsync()); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpGet("get-activas")]
        public async Task<IActionResult> GetActivas()
        {
            try { return Ok(await _svc.GetActivas()); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] VisitaAutorizadaCreateRequest req)
        {
            try { return Ok(await _svc.Create(req)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] VisitaAutorizadaUpdateRequest req)
        {
            try { return Ok(await _svc.Update(req)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPatch("estado/{id}")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] string estado)
        {
            try { return Ok(await _svc.CambiarEstado(id, estado)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }
    }

}
