using Microsoft.AspNetCore.Mvc;

using WebApplication30.Dto;

namespace WebApplication30.Controllers
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
            _logger.LogTrace("This is a Trace log message");
            return Content("Ok");
        }

        public IActionResult Debug()
        {
            _logger.LogDebug("This is a Debug log message");
            return Content("Ok");
        }

        public IActionResult Info()
        {
            _logger.LogInformation("This is a Info log message");
            _logger.LogInformation("This is a Info log message: {String}", "StringValue");
            _logger.LogInformation("This is a Info log message: {@Email}", "1506816370@qq.com");
            _logger.LogInformation("This is a Info log message: {@UserInfo}", new UserInfoDto
            {
                Name = "John Doe",
                Email = "1506816370@qq.com"
            });
            return Content("Ok");
        }

        public IActionResult Warn()
        {
            _logger.LogWarning("This is a Warning log message");
            return Content("Ok");
        }

        public IActionResult Error()
        {
            try
            {
                int n = Convert.ToInt32("abc");
                n = 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "This is a error log message");
            }
            return Content("Ok");
        }

        public IActionResult Critical()
        {
            try
            {
                int n = Convert.ToInt32("cba");
                n = 2;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "This is a Critical log message");
            }
            return Content("Ok");
        }
    }
}
