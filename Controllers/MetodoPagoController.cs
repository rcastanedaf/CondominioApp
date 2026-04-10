using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetodoPagoController : ControllerBase
    {
        private readonly IMetodoPagoService metodoPagoService;

        public MetodoPagoController(IMetodoPagoService metodoPagoService)
        {
            this.metodoPagoService = metodoPagoService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await metodoPagoService.GetAllAsync();

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] MetodoPagoCreateRequest request)
        {
            try
            {
                var response = await metodoPagoService.CreateAsync(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromBody] MetodoPagoModel request, int id)
        {
            try
            {
                var response = await metodoPagoService.UpdateAsync(request, id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await metodoPagoService.DeleteAsync(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
