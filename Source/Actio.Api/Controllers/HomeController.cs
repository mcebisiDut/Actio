using Microsoft.AspNetCore.Mvc;

namespace Actio.API.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Actio API");      
    }
}