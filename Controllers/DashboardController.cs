using Condominio.DTOs.Response;
using Condominio.Models;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(IDashboardService service, ILogger<DashboardController> logger)
        {
            _service = service;
            _logger = logger;
        }

        private IActionResult Err(Exception ex, string ctx)
        {
            _logger.LogError(ex, ctx);
            return StatusCode(500, new ApiResponse<string> { Success = false, Message = ex.Message });
        }

        [HttpGet("get-resumen")]
        public async Task<IActionResult> GetResumen()
        {
            try { return Ok(new ApiResponse<DashboardModel> { Success = true, Message = "OK", Data = await _service.GetDashboardAsync() }); }
            catch (Exception ex) { return Err(ex, "Error dashboard general"); }
        }

        [HttpGet("get-financiero")]
        public async Task<IActionResult> GetFinanciero()
        {
            try { return Ok(new ApiResponse<DashboardFinancieroModel> { Success = true, Message = "OK", Data = await _service.GetDashboardFinancieroAsync() }); }
            catch (Exception ex) { return Err(ex, "Error dashboard financiero"); }
        }

        [HttpGet("get-residentes")]
        public async Task<IActionResult> GetResidentes()
        {
            try { return Ok(new ApiResponse<DashboardResidentesModel> { Success = true, Message = "OK", Data = await _service.GetDashboardResidentesAsync() }); }
            catch (Exception ex) { return Err(ex, "Error dashboard residentes"); }
        }

        [HttpGet("get-acceso")]
        public async Task<IActionResult> GetAcceso()
        {
            try { return Ok(new ApiResponse<DashboardAccesoModel> { Success = true, Message = "OK", Data = await _service.GetDashboardAccesoAsync() }); }
            catch (Exception ex) { return Err(ex, "Error dashboard acceso"); }
        }

        [HttpGet("get-incidencias")]
        public async Task<IActionResult> GetIncidencias()
        {
            try { return Ok(new ApiResponse<DashboardIncidenciasModel> { Success = true, Message = "OK", Data = await _service.GetDashboardIncidenciasAsync() }); }
            catch (Exception ex) { return Err(ex, "Error dashboard incidencias"); }
        }

        [HttpGet("get-espacios")]
        public async Task<IActionResult> GetEspacios()
        {
            try { return Ok(new ApiResponse<DashboardEspaciosModel> { Success = true, Message = "OK", Data = await _service.GetDashboardEspaciosAsync() }); }
            catch (Exception ex) { return Err(ex, "Error dashboard espacios"); }
        }

        [HttpGet("get-personal")]
        public async Task<IActionResult> GetPersonal()
        {
            try { return Ok(new ApiResponse<DashboardPersonalModel> { Success = true, Message = "OK", Data = await _service.GetDashboardPersonalAsync() }); }
            catch (Exception ex) { return Err(ex, "Error dashboard personal"); }
        }

        [HttpGet("get-contratos")]
        public async Task<IActionResult> GetContratos()
        {
            try { return Ok(new ApiResponse<DashboardContratosModel> { Success = true, Message = "OK", Data = await _service.GetDashboardContratosAsync() }); }
            catch (Exception ex) { return Err(ex, "Error dashboard contratos"); }
        }

        [HttpGet("get-multas")]
        public async Task<IActionResult> GetMultas()
        {
            try { return Ok(new ApiResponse<DashboardMultasModel> { Success = true, Message = "OK", Data = await _service.GetDashboardMultasAsync() }); }
            catch (Exception ex) { return Err(ex, "Error dashboard multas"); }
        }
    }
}