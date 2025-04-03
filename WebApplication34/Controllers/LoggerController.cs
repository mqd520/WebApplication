using Microsoft.AspNetCore.Mvc;

namespace WebApplication34.Controllers
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
            _logger.LogTrace("This is a [Trace] log message.");
            return Content("Trace");
        }

        public IActionResult Debug()
        {
            _logger.LogDebug("This is a [Debug] log message.");
            return Content("Debug");
        }

        public IActionResult Info()
        {
            _logger.LogInformation("This is a [Info] log message.");
            return Content("Info");
        }

        public IActionResult Warn()
        {
            _logger.LogWarning("This is a [Warn] log message.");
            return Content("Warn");
        }

        public IActionResult Error()
        {
            try
            {
                int n = Convert.ToInt32("djjdk");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "This is a [Error] log message.");
            }

            return Content("Error");
        }

        public IActionResult Critical()
        {
            try
            {
                int n = Convert.ToInt32("deef");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "This is a [Critical] log message.");
            }

            return Content("Critical");
        }
    }
}
