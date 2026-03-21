using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services;
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
            var response = new List<ParentescoModel>();

            try
            {
                response = await _testService.GetAll();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] ParentescoRequest request)
        {
            try
            {
                var response = await _testService.Create(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromBody] ParentescoModel request, int id)
        {
            try
            {
                var response = await _testService.Update(request, id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _testService.Delete(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
