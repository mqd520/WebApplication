using Microsoft.AspNetCore.Mvc;

using WebApplication14.Services;

namespace WebApplication14.Controllers
{
    public class MyAspectController : Controller
    {
        private readonly IUserService _userService;

        public MyAspectController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            _userService.Fun1();
            return View();
        }
    }
}
