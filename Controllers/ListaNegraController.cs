using Condominio.DTOs.Request;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaNegraController : ControllerBase
    {
        private readonly IListaNegraService _svc;
        public ListaNegraController(IListaNegraService svc) => _svc = svc;

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try { return Ok(await _svc.GetAllAsync()); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ListaNegraCreateRequest req)
        {
            try { return Ok(await _svc.Create(req)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] ListaNegraUpdateRequest req)
        {
            try { return Ok(await _svc.Update(req)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpDelete("desactivar/{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            try { return Ok(await _svc.Desactivar(id)); }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }
    }

}
