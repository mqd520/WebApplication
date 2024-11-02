using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class AOPController : Controller
    {
        private readonly ILogger<AOPController> _logger;

        public AOPController(ILogger<AOPController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
    }
}
