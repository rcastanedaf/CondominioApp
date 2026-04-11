using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoMonedaController : ControllerBase
    {
        private readonly ITipoMonedaService _tipoMonedaService;

        public TipoMonedaController(ITipoMonedaService tipoMonedaService)
        {
            _tipoMonedaService = tipoMonedaService;
        }

        [HttpGet]
        [Route("get-all-tipo-moneda")]
        public async Task<IActionResult> GetAll()
        {
            var response = new List<TipoMonedaModel>();

            try
            {
                response = await _tipoMonedaService.GetAllAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create-tipo-moneda")]
        public async Task<IActionResult> Create([FromBody] TipoMonedaCreateRequest request)
        {
            try
            {
                var response = await _tipoMonedaService.CreateAsync(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-tipo-moneda/{id}")]
        public async Task<IActionResult> Update([FromBody] TipoMonedaModel request, int id)
        {
            try
            {
                var response = await _tipoMonedaService.UpdateAsync(request, id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete-tipo-moneda/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _tipoMonedaService.DeleteAsync(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
