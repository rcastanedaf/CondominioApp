using Condominio.DTOs.Request;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroAccesoController : ControllerBase
    {
        private readonly IRegistroAccesoService _svc;
        public RegistroAccesoController(IRegistroAccesoService svc) => _svc = svc;

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int top = 200)
        {
            try { return Ok(await _svc.GetAllAsync(top)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpGet("get-by-fecha")]
        public async Task<IActionResult> GetByFecha([FromQuery] string desde, [FromQuery] string hasta)
        {
            try { return Ok(await _svc.GetByFecha(desde, hasta)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RegistroAccesoCreateRequest req)
        {
            try { return Ok(await _svc.Create(req)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }
    }

}
