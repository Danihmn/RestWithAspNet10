using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private static long _counter = 0;
        private static readonly string _template = "Hello, {0}!";

        [HttpGet]
        public GreetingModel Get ([FromQuery] string name = "World")
        {
            var id = Interlocked.Increment(ref _counter);
            var content = string.Format(_template, name);

            return new(1, content);
        }
    }
}
