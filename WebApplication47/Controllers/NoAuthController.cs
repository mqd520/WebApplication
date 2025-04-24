using Microsoft.AspNetCore.Mvc;

namespace WebApplication47.Controllers
{
    public class NoAuthController : Controller
    {
        public IActionResult Index()
        {
            return Content("No Auth");
        }
    }
}
