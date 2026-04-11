using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

[ApiController]
[Route("api/[controller]")]
public class gravamenPropiedadController : ControllerBase
{
    private readonly IgravamenPropiedadService _service;

    public gravamenPropiedadController(IgravamenPropiedadService service)
    {
        _service = service;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        var data = await _service.GetAll();
        return Ok(data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] gravamenPropiedadRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var result = await _service.Create(request);
            return Ok(result);
        }
        catch (OracleException ex)
        {
            // Muestra el error de Oracle en la respuesta en lugar de colgarse
            return BadRequest(new { error = ex.Message, code = ex.Number });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] gravamenPropiedadModel request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.Update(request, id);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok();
    }
}