using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("Incidencia")]
    public class IncidenciaController : ControllerBase
    {
        private readonly IIncidenciaService _service;

        public IncidenciaController(IIncidenciaService service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] IncidenciaModel model)
        {
            await _service.CreateAsync(model);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] IncidenciaModel model)
        {
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