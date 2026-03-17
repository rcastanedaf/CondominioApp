using Condominio.DTOs.Request;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParentescoController : ControllerBase
    {
        private readonly IParentescoService _testService;

        public ParentescoController(IParentescoService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> Get()
        {
            var result = await _testService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] ParentescoRequest request)
        {
            var result = await _testService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _testService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ParentescoRequest request)
        {
            var result = await _testService.Update(id, request);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _testService.Delete(id);

            if (result == null)
                return NotFound();

            return Ok("Eliminado correctamente");
        }
    }
}
