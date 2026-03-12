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
        [Route("get-all")]
        public async Task<IActionResult> Get()
        {
            var result = await _bancoService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("get-id")]
        public async Task<IActionResult> GetId([FromBody] int id)
        {
            var result = await _bancoService.GetId(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-nombre")]
        public async Task<IActionResult> GetNombre([FromBody] string nombre)
        {
            var result = await _bancoService.GetNombre(nombre);
            return Ok(result);
        }

        [HttpPost]
        [Route("create/{id}")]
        public async Task<IActionResult> CreateBanco([FromBody] BancoRequest request)
        {
            Banco newBanco = new Banco
            {
                Nombre = request.Nombre,
                Pais = request.Pais,
                Activo = request.Activo,
            };
            var result = await _bancoService.CreateBanco(newBanco);
            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateBanco([FromBody] BancoRequest request) 
        {
            Banco editBanco = new Banco
            {
                Id = request.Id,
                Nombre = request.Nombre,
                Pais = request.Pais,
                Activo = request.Activo,
            };
            var result = await _bancoService.CreateBanco(editBanco);
            return Ok(result);
        }

        [HttpDelete]
        [Route("detele/{id}")]
        public async Task<IActionResult> DeleteBanco([FromBody] int id)
        {
            var result = await _bancoService.DeleteBanco(id);
            return Ok(result);
        }
    }
}
