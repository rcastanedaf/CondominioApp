using Condominio.DTOs.Request;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

[ApiController]
[Route("api/[controller]")]
public class renovacionContratoController : ControllerBase
{
    private readonly IrenovacionContratoService _service;

    public renovacionContratoController(IrenovacionContratoService service)
    {
        _service = service;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var data = await _service.GetAll();
            return Ok(data);
        }
        catch (OracleException ex) { return BadRequest(new { error = ex.Message, code = ex.Number }); }
        catch (Exception ex) { return StatusCode(500, new { error = ex.Message }); }
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] renovacionContratoRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            var result = await _service.Create(request);
            return Ok(result);
        }
        catch (OracleException ex) { return BadRequest(new { error = ex.Message, code = ex.Number }); }
        catch (Exception ex) { return StatusCode(500, new { error = ex.Message }); }
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] renovacionContratoModel request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            var result = await _service.Update(request, id);
            return Ok(result);
        }
        catch (OracleException ex) { return BadRequest(new { error = ex.Message, code = ex.Number }); }
        catch (Exception ex) { return StatusCode(500, new { error = ex.Message }); }
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.Delete(id);
            return Ok();
        }
        catch (OracleException ex) { return BadRequest(new { error = ex.Message, code = ex.Number }); }
        catch (Exception ex) { return StatusCode(500, new { error = ex.Message }); }
    }
}