using Microsoft.AspNetCore.Mvc;


namespace CrudExample.Controllers
{
    [ApiController]
    public class Heartbeat : Controller
    {
        [HttpGet]
        [Route("api/Heartbeat")]
        public IActionResult Get()
        {
            return Ok("API is running...");
        }
    }
}
