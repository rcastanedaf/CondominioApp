using Microsoft.AspNetCore.Mvc;

namespace Condominio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoMonedaController : ControllerBase
    {
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
