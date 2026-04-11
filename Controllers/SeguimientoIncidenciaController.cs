using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("SeguimientoIncidencia")]
    public class SeguimientoIncidenciaController : ControllerBase
    {
        private readonly ISeguimientoIncidenciaService _service;

        public SeguimientoIncidenciaController(ISeguimientoIncidenciaService service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("get-by-incidencia")]
        public async Task<IActionResult> GetByIncidencia(int idIncidencia) // ✅ antes era "id"
        {
            var data = await _service.GetByIncidenciaAsync(idIncidencia);
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SeguimientoIncidenciaModel model)
        {
            await _service.CreateAsync(model);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SeguimientoIncidenciaModel model)
        {
            model.IdSeguimiento = id;
            await _service.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}