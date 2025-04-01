using Microsoft.AspNetCore.Mvc;

namespace WebApplication31.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILogger<LoggerController> _logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Trace()
        {
            _logger.LogTrace("This is a [Trace] log message");
            return Ok("Ok");
        }

        public IActionResult Debug()
        {
            _logger.LogDebug("This is a [Debug] log message");
            return Ok("Ok");
        }

        public IActionResult Info()
        {
            _logger.LogInformation("This is a [Info] log message");
            _logger.LogInformation("This is a [Info] log message {String}", "StringValue");
            return Ok("Ok");
        }

        public IActionResult Warn()
        {
            _logger.LogWarning("This is a [Warn] log message");
            return Ok("Ok");
        }

        public IActionResult Error()
        {
            try
            {
                int n = Convert.ToInt32("abc");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "This is a [Error] log message");
            }

            return Ok("Ok");
        }

        public IActionResult Critical()
        {
            try
            {
                int n = Convert.ToInt32("abc");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "This is a [Critical] log message");
            }

            return Ok("Ok");
        }
    }
}
