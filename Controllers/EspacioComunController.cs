using Condominio.DTOs.Request;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EspacioComunController : ControllerBase
    {
        private readonly IEspacioComunService _svc;
        public EspacioComunController(IEspacioComunService svc) => _svc = svc;

        [HttpGet("get-all")] public async Task<IActionResult> GetAll() { try { return Ok(await _svc.GetAllAsync()); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
        [HttpPost("create")] public async Task<IActionResult> Create([FromBody] EspacioComunCreateRequest req) { try { return Ok(await _svc.Create(req)); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
        [HttpPut("update/{id}")] public async Task<IActionResult> Update([FromBody] EspacioComunUpdateRequest req) { try { return Ok(await _svc.Update(req)); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
        [HttpPatch("estado/{id}")] public async Task<IActionResult> Estado(int id, [FromBody] string estado) { try { return Ok(await _svc.CambiarEstado(id, estado)); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }
        [HttpDelete("delete/{id}")] public async Task<IActionResult> Delete(int id) { try { return Ok(await _svc.Delete(id)); } catch (Exception ex) { return BadRequest(new { message = ex.Message }); } }

    }
}
