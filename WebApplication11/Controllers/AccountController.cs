using Microsoft.AspNetCore.Mvc;
using WebApplication11.DTO;
using WebApplication11.Service;

namespace WebApplication11.Controllers
{
    public class AccountController : Controller
    {
        private readonly IJWTService _jwtService;

        public AccountController(IJWTService jwtService)
        {
            _jwtService = jwtService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(UserLoginInfoDTO ui)
        {
            if (ui.Username.Equals("admin") && ui.Password.Equals("123456"))
            {
                var token = _jwtService.GetTokenWithModel(new JWTUserInfoDTO
                {
                    UserName = ui.Username,
                    Name = "Administrator"
                });

                HttpContext.Response.Cookies.Append(".aspnetcore.jwt", token, new CookieOptions
                {
                    HttpOnly = true
                });
                return Redirect("/");

                //return Ok(token);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
