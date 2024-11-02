using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication9.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string username, string password)
        {
            if (username.Equals("admin") && password.Equals("123456"))
            {
                var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, username)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddMinutes(10),
                    AllowRefresh = true
                };
                await HttpContext.SignInAsync(principal, properties);
                return Redirect("/");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
