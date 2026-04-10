using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("CategoriaIncidencia")]
    public class CategoriaIncidenciaController : ControllerBase
    {
        private readonly ICategoriaIncidenciaService _service;

        public CategoriaIncidenciaController(ICategoriaIncidenciaService service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoriaIncidenciaModel model)
        {
            await _service.CreateAsync(model);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CategoriaIncidenciaModel model)
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