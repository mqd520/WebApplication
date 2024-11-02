using Microsoft.AspNetCore.Mvc;

using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class UserServiceController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserService _userService2;

        public UserServiceController(IUserService userService, IUserService userService2)
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
