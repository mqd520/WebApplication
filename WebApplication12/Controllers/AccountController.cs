using Microsoft.AspNetCore.Mvc;

using WebApplication12.Validators;
using WebApplication12.VO;

namespace WebApplication12.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserLoginInfoValidator _userLoginValidator;
        private readonly UserLoginInfo2Validator _userLogin2Validator;

        public AccountController(UserLoginInfoValidator userLoginValidator
            , UserLoginInfo2Validator userLogin2Validator)
        {
            _userLoginValidator = userLoginValidator;
            _userLogin2Validator = userLogin2Validator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInfoVO userLoginInfoDTO)
        {
            var result = _userLoginValidator.Validate(userLoginInfoDTO);
            if (result.IsValid)
            {
                return new ContentResult { Content = "Success" };
            }
            else
            {
                return new ContentResult { Content = "Fail: " + string.Join(Environment.NewLine, result.Errors) };
            }
        }

        public IActionResult Login2(UserLoginInfo2VO userLoginInfo2DTO)
        {
            var result = _userLogin2Validator.Validate(userLoginInfo2DTO);
            if (result.IsValid)
            {
                return new ContentResult { Content = "Success" };
            }
            else
            {
                return new ContentResult { Content = "Fail: " + string.Join(Environment.NewLine, result.Errors) };
            }
        }
    }
}
