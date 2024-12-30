
using Microsoft.AspNetCore.Mvc;


namespace MyDemoAPI.Controllers
{
    [Route("[controller]")]
    public class MyDemoController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        }
}