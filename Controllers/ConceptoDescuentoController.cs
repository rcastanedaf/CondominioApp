using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [Route("get-allConceptoDesc")]
        public async Task<IActionResult> Get()
        {
            var result = await _conceptoDescuentoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("get-idConceptoDesc")]
        public async Task<IActionResult> GetId([FromBody] int id)
        {
            var result = await _conceptoDescuentoService.GetId(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-nombreConceptoDesc")]
        public async Task<IActionResult> GetNombre([FromBody] string nombre)
        {
            var result = await _conceptoDescuentoService.GetNombre(nombre);
            return Ok(result);
        }

        [HttpPost]
        [Route("createConceptoDesc/{id}")]
        public async Task<IActionResult> CreateBanco([FromBody] ConceptoDescuentoRequest request)
        {
            Concepto_Descuento newConceptoDescuento = new Concepto_Descuento
            {
                Nombre = request.Nombre,
                Tipo = request.Tipo,
                Valor = request.Valor,
                Autorizacion = request.Autorizacion,
            };
            var result = await _conceptoDescuentoService.CreateConceptoDescuento(newConceptoDescuento);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateConceptoDesc/{id}")]
        public async Task<IActionResult> UpdateBanco([FromBody] ConceptoDescuentoRequest request)
        {
            Concepto_Descuento editConceptoDescuento = new Concepto_Descuento
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Tipo = request.Tipo,
                Valor = request.Valor,
                Autorizacion = request.Autorizacion,
            };
            var result = await _conceptoDescuentoService.UpdateConceptoDescuento(editConceptoDescuento);
            return Ok(result);
        }

        [HttpDelete]
        [Route("deteleConceptoDesc/{id}")]
        public async Task<IActionResult> DeleteBanco([FromBody] int id)
        {
            var result = await _conceptoDescuentoService.DeleteConceptoDescuento(id);
            return Ok(result);
        }

    }
}
