using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult Error() => Problem();
    }
}
