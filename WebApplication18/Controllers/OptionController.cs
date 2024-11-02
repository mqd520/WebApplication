using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using WebApplication18.Options;

namespace WebApplication18.Controllers
{
    public class OptionController : Controller
    {
        private readonly UserInfoOptions _userInfoOptions;
        private readonly UserExtraInfoOptions _userExtraInfoOptions;

        public OptionController(IOptions<UserInfoOptions> options
            , IOptions<UserExtraInfoOptions> userExtraInfoOptions)
        {
            _userInfoOptions = options.Value;
            _userExtraInfoOptions = userExtraInfoOptions.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUserInfo()
        {
            return new JsonResult(_userInfoOptions);
        }

        public IActionResult GetUserExtraInfo()
        {
            return new JsonResult(_userExtraInfoOptions);
        }
    }
}
