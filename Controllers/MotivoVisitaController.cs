using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotivoVisitaController : ControllerBase
    {
        private readonly IMotivoVisitaService _service;

        public MotivoVisitaController(IMotivoVisitaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-all-motivo-visita")]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("create-motivo-visita")]
        public async Task<IActionResult> Create([FromBody] MotivoVisitaModel model)
        {
            var result = await _service.CreateAsync(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("update-motivo-visita")]
        public async Task<IActionResult> Update([FromBody] MotivoVisitaModel model)
        {
            var result = await _service.UpdateAsync(model);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete-motivo-visita/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }
    }
}