using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("Pago")]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _service;

        public PagoController(IPagoService service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet("get-by-factura/{idFactura}")]
        public async Task<IActionResult> GetByFactura(int idFactura)
        {
            var data = await _service.GetByFacturaAsync(idFactura);
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] PagoModel model)
        {
            await _service.CreateAsync(model);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PagoModel model)
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
