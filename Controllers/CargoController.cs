using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }


        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new List<CargoModel>();

            try
            {
                response = await _cargoService.GetAllAsync();
                 return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
      

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Creat([FromBody] CargoCreateRequest request)
        {
            try
            {
                var response = await _cargoService.Create(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update([FromBody] CargoUpdateRequest request)
        {
            try
            {
                var response = await _cargoService.Update(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("detele/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var response = await _cargoService.Delete(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); ;
            }
        }

    }
}

