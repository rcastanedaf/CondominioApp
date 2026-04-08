using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MultaController : ControllerBase
    {
        private readonly IMultaService _multaService;

        public MultaController(IMultaService multaService)
        {
            _multaService = multaService;
        }


        [HttpGet]
        [Route("get-all-multa")]
        public async Task<IActionResult> Get()
        {
            var response = new List<Multa>();

            try
            {
                response = await _multaService.GetAllAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-id-multa")]
        public async Task<IActionResult> GetId([FromBody] int id)
        {
            var response = new List<Multa>();

            try
            {
                response = await _multaService.GetId(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-nombre-multa")]
        public async Task<IActionResult> GetNombre([FromBody] string nombre)
        {
            var response = new List<Multa>();

            try
            {
                response = await _multaService.GetNombre(nombre);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create-multa")]
        public async Task<IActionResult> CreateMulta([FromBody] MultaCreateRequest request)
        {
            try
            {
                var response = await _multaService.CreateMulta(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-multa/{id}")]
        public async Task<IActionResult> UpdateMulta([FromBody] MultaUpdateRequest request)
        {
            try
            {
                var response = await _multaService.UpdateMulta(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("detele-multa/{id}")]
        public async Task<IActionResult> DeleteMulta([FromRoute] int id)
        {
            try
            {
                var response = await _multaService.DeleteMulta(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); ;
            }
        }
    }
}
