using Microsoft.AspNetCore.Mvc;

namespace WebApplication9.Controllers
{
    public class ForbiddenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
