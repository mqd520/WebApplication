using Microsoft.AspNetCore.Mvc;

namespace WebApplication23.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
