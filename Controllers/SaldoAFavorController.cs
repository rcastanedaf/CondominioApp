using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaldoAFavorController : ControllerBase
    {
        private readonly ISaldoAFavorService _saldoAFavorService;

        public SaldoAFavorController(ISaldoAFavorService saldoAFavorService)
        {
            _saldoAFavorService = saldoAFavorService;
        }


        [HttpGet]
        [Route("get-all-saldoAFavor")]
        public async Task<IActionResult> Get()
        {
            var response = new List<SaldoAFavor>();

            try
            {
                response = await _saldoAFavorService.GetAllAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-id-saldoAFavor")]
        public async Task<IActionResult> GetId([FromBody] int id)
        {
            var response = new List<SaldoAFavor>();

            try
            {
                response = await _saldoAFavorService.GetId(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-nombre-saldoAFavor")]
        public async Task<IActionResult> GetNombre([FromBody] string nombre)
        {
            var response = new List<SaldoAFavor>();

            try
            {
                response = await _saldoAFavorService.GetNombre(nombre);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create-saldoAFavor")]
        public async Task<IActionResult> CreateSaldoAFavor([FromBody] SaldoAFavorCreateRequest request)
        {
            try
            {
                var response = await _saldoAFavorService.CreateSaldoAFavor(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-saldoAFavor/{id}")]
        public async Task<IActionResult> UpdateSaldoAFavor([FromBody] SaldoAFavorUpdateRequest request)
        {
            try
            {
                var response = await _saldoAFavorService.UpdateSaldoAFavor(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("detele-saldoAFavor/{id}")]
        public async Task<IActionResult> DeleteSaldoAFavor([FromRoute] int id)
        {
            try
            {
                var response = await _saldoAFavorService.DeleteSaldoAFavor(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); ;
            }
        }
    }
}
