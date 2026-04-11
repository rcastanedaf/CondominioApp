using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResidenteController : ControllerBase
    {
        private readonly IResidenteService _residenteService;

        public ResidenteController(IResidenteService residenteService)
        {
            _residenteService = residenteService;
        }


        [HttpGet]
        [Route("get-all-residente")]
        public async Task<IActionResult> Get()
        {
            var response = new List<Residente>();

            try
            {
                response = await _residenteService.GetAllAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-id-residente")]
        public async Task<IActionResult> GetId([FromBody] int id)
        {
            var response = new List<Residente>();

            try
            {
                response = await _residenteService.GetId(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-nombre-residente")]
        public async Task<IActionResult> GetNombre([FromBody] string nombre)
        {
            var response = new List<Residente>();

            try
            {
                response = await _residenteService.GetNombre(nombre);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create-residente")]
        public async Task<IActionResult> CreateResidente([FromBody] ResidenteCreateRequest request)
        {
            try
            {
                var response = await _residenteService.CreateResidente(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-residente/{id}")]
        public async Task<IActionResult> UpdateResidente(int id, [FromBody] ResidenteUpdateRequest request)
        {
            try
            {
                request.Id_Residente = id;
                var response = await _residenteService.UpdateResidente(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete-residente/{id}")]  // ✅ antes era "detele-residente"
        public async Task<IActionResult> DeleteResidente([FromRoute] int id)
        {
            try
            {
                var response = await _residenteService.DeleteResidente(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
