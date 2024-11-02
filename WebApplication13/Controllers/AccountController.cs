using Microsoft.AspNetCore.Mvc;

using WebApplication13.DTO;
using WebApplication13.Filters;
using WebApplication13.Validators;

namespace WebApplication13.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(ValidatorFilter)
            , Arguments = [typeof(UserLoginInfoDTOValidator), typeof(UserLoginInfoDTO)])]
        public IActionResult Login(UserLoginInfoDTO userLoginInfoDTO)
        {
            return new ContentResult { Content = "Success" };
        }

        [HttpPost]
        [TypeFilter(typeof(ValidatorFilter)
            , Arguments = [typeof(UserLoginInfo2DTOValidator), typeof(UserLoginInfo2DTO)])]
        public IActionResult Login2(UserLoginInfo2DTO userLoginInfo2DTO)
        {
            return new ContentResult { Content = "Success" };
        }
    }
}