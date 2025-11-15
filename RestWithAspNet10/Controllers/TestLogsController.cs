using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet10.Controllers
{
    [ApiController]
    [Route("api/test/[controller]")]
    public class TestLogsController : ControllerBase
    {
        private readonly ILogger _logger;

        public TestLogsController (ILogger<TestLogsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult LogTest ()
        {
            _logger.LogTrace("This is an trace log");
            _logger.LogDebug("This is a debug log.");
            _logger.LogInformation("This is an information log.");
            _logger.LogWarning("This is a warning log.");
            _logger.LogError("This is an error log.");
            _logger.LogCritical("This is a critical log.");

            return Ok("Many logs have been generated, check you logging output");
        }
    }
}
