using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc; 

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _paisService;

        public PaisController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> Get()
        {
            var response = new List<PaisModel>();

            try
            {
                response = await _paisService.GetAll();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] PaisRequest request)
        {
            try
            {
                var response = await _paisService.Create(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }

        /*[HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _paisService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }*/

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromBody] PaisModel request, int id)
        {
            try
            {
                var response = await _paisService.Update(request, id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _paisService.Delete(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }
    }
}
