using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConceptoDescuentoController : ControllerBase
    {
        private readonly IConceptoDescuentoService _conceptoDescuentoService;

        public ConceptoDescuentoController(IConceptoDescuentoService conceptoDescuentoService)
        {
            _conceptoDescuentoService = conceptoDescuentoService;
        }


        [HttpGet]
        [Route("get-all-ConceptoDesc")]
        public async Task<IActionResult> Get()
        {
            var response = new List<Concepto_Descuento>();

            try
            {
                response = await _conceptoDescuentoService.GetAllAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-id-ConceptoDesc")]
        public async Task<IActionResult> GetId(int id)
        {
            var response = new List<Concepto_Descuento>();

            try
            {
                response = await _conceptoDescuentoService.GetId(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-nombre-ConceptoDesc")]
        public async Task<IActionResult> GetNombre(string nombre)
        {
            var response = new List<Concepto_Descuento>();

            try
            {
                response = await _conceptoDescuentoService.GetNombre(nombre);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("create-ConceptoDesc")]
        public async Task<IActionResult> CreateConceptoDesc([FromBody] ConceptoDescuentoCreateRequest request)
        {
            try
            {
                var response = await _conceptoDescuentoService.CreateConceptoDescuento(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-ConceptoDesc/{id}")]
        public async Task<IActionResult> UpdateConceptoDes([FromBody] ConceptoDescuentoUpdateRequest request)
        {
            try
            {
                var response = await _conceptoDescuentoService.UpdateConceptoDescuento(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete-ConceptoDesc/{id}")]
        public async Task<IActionResult> DeleteConceptoDesc([FromRoute] int id)
        {
            try
            {
                var response = await _conceptoDescuentoService.DeleteConceptoDescuento(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); ;
            }
        }

    }
}
