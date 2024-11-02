using Microsoft.AspNetCore.Mvc;

using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class User2ServiceController : Controller
    {
        private readonly IUser2Service _userService;
        private readonly IUser2Service _userService2;

        public User2ServiceController(IUser2Service userService, IUser2Service userService2)
        {
            _userService = userService;
            _userService2 = userService2;
        }

        public IActionResult Index()
        {
            var text = _userService.Fun1();
            return new ContentResult { Content = text };
        }

        public IActionResult Index2()
        {
            var flag = _userService == _userService2;
            return new ContentResult { Content = flag.ToString() };
        }
    }
}
