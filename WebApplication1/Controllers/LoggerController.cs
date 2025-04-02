using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
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

        public IActionResult Info()
        {
            _logger.LogInformation("This is a [Info] log message");
            return Content("Info");
        }

        public IActionResult Error()
        {
            try
            {
                int n = Convert.ToInt32("nnn");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "This is a Error log message");
            }
            return Content("Error");
        }
    }
}
