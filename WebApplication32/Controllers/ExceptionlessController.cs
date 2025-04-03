using Exceptionless;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication32.Controllers
{
    public class ExceptionlessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitLog()
        {
            ExceptionlessClient.Default.SubmitLog("This is a [Trace] log message", Exceptionless.Logging.LogLevel.Trace);
            ExceptionlessClient.Default.SubmitLog("This is a [Debug] log message", Exceptionless.Logging.LogLevel.Debug);
            ExceptionlessClient.Default.SubmitLog("This is a [Info] log message", Exceptionless.Logging.LogLevel.Info);
            ExceptionlessClient.Default.SubmitLog("This is a [Warn] log message", Exceptionless.Logging.LogLevel.Warn);
            ExceptionlessClient.Default.SubmitLog("This is a [Error] log message", Exceptionless.Logging.LogLevel.Error);
            ExceptionlessClient.Default.SubmitLog("This is a [Fatal] log message", Exceptionless.Logging.LogLevel.Fatal);
            return Content("SubmitLog");
        }
    }
}
