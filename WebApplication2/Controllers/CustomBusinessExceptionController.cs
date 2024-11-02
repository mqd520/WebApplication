using Microsoft.AspNetCore.Mvc;

using WebApplication2.Def.Enum;
using WebApplication2.Exceptions;

namespace WebApplication2.Controllers
{
    public class CustomBusinessExceptionController : Controller
    {
        public IActionResult Index([FromQuery] string username, [FromQuery] string password)
        {
            if (!(username.Equals("admin", StringComparison.OrdinalIgnoreCase)
                && password.Equals("123456", StringComparison.OrdinalIgnoreCase)))
            {
                throw new CustomBusinessException((int)CustomReturnResultCodeEnum.UserNameAndPasswordNotMatch, "Invalid Username Or Pasword!");
            }

            return View();
        }

        public IActionResult Index2()
        {
            if (Request.Query["username"].Count == 0)
            {
                throw new Exception("username is null");
            }
            return View();
        }
    }
}