using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication47.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return Content("Auth");
        }
    }
}
