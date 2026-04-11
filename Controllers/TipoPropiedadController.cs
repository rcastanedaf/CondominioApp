using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoPropiedadController : ControllerBase
    {
        private readonly ITipoPropiedadService _tipoPropiedadService;

        public TipoPropiedadController(ITipoPropiedadService tipoPropiedadService)
        {
            _tipoPropiedadService = tipoPropiedadService;
        }


        [HttpGet]
        [Route("get-all-tipo-propiedad")]
        public async Task<IActionResult> Get()
        {
            var response = new List<Tipo_Propiedad>();

            try
            {
                response = await _tipoPropiedadService.GetAllAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-id-tipo-propiedad")]
        public async Task<IActionResult> GetId([FromBody] int id)
        {
            var response = new List<Tipo_Propiedad>();

            try
            {
                response = await _tipoPropiedadService.GetId(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-nombre-tipo-propiedad")]
        public async Task<IActionResult> GetNombre([FromBody] string nombre)
        {
            var response = new List<Tipo_Propiedad>();

            try
            {
                response = await _tipoPropiedadService.GetNombre(nombre);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create-tipo-propiedad")]
        public async Task<IActionResult> CreateTipoPropiedad([FromBody] TipoPropiedadCreateRequest request)
        {
            try
            {
                var response = await _tipoPropiedadService.CreateTipoPropiedad(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-tipo-propiedad/{id}")]
        public async Task<IActionResult> UpdateTipoPropiedad([FromBody] TipoPropiedadUpdateRequest request)
        {
            try
            {
                var response = await _tipoPropiedadService.UpdateTipoPropiedad(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("detele-tipo-propiedad/{id}")]
        public async Task<IActionResult> DeleteTipoPropiedad([FromRoute] int id)
        {
            try
            {
                var response = await _tipoPropiedadService.DeleteTipoPropiedad(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); ;
            }
        }
    }
}
