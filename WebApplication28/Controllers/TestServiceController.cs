using Microsoft.AspNetCore.Mvc;

namespace WebApplication28.Controllers
{
    public class TestServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            StaticHelper.Fun1();
            return Ok("Ok");
        }
    }
}
