using Microsoft.AspNetCore.Mvc;

namespace WebApplication44.Controllers
{
    [ApiController]
    [Route("~/[Controller]/[Action]")]
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger, IHostApplicationLifetime lifetime)
        {
            lifetime.ApplicationStarted.Register(() =>
            {
                logger.LogInformation("ApplicationStarted!");
            });
        }

        public IActionResult Index()
        {
            return Content("/Home/Index");
        }
    }
}
