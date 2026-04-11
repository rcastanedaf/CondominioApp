using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }


        [HttpGet]
        [Route("get-all-banco")]
        public async Task<IActionResult> Get()
        {
            var response = new List<Banco>();

            try
            {
                response = await _bancoService.GetAllAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-id-banco")]
        public async Task<IActionResult> GetId([FromBody] int id)
        {
            var response = new List<Banco>();

            try
            {
                response = await _bancoService.GetId(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-nombre-banco")]
        public async Task<IActionResult> GetNombre([FromBody] string nombre)
        {
            var response = new List<Banco>();

            try
            {
                response = await _bancoService.GetNombre(nombre);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create-banco")]
        public async Task<IActionResult> CreateBanco([FromBody] BancoCreateRequest request)
        {
            try
            {
                var response = await _bancoService.CreateBanco(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-banco/{id}")]
        public async Task<IActionResult> UpdateBanco([FromBody] BancoUpdateRequest request) 
        {
            try
            {
                var response = await _bancoService.UpdateBanco(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("detele-banco/{id}")]
        public async Task<IActionResult> DeleteBanco([FromRoute] int id)
        {
            try
            {
                var response = await _bancoService.DeleteBanco(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); ;
            }
        }
    }
}
