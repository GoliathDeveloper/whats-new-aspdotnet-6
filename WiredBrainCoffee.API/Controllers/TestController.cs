using Microsoft.AspNetCore.Mvc;

namespace WiredBrainCoffee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet()]
        public IActionResult GetGreeting()
        {
            return Ok("Hello on save!");
        }
    }
}