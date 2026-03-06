using Condominio.DTOs.Request;
using Condominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> Get()
        {
            var result = await _testService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("create/{id}")]
        public async Task<IActionResult> Create([FromBody] TestRequest request)
        {
            return Ok();
        }
    }
}
