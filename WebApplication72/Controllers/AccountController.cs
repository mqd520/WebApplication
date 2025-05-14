using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication72.Common;
using WebApplication72.Def;
using WebApplication72.Filter;

namespace WebApplication72.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResultData> Login(string? ReturnUrl)
        {
            var claims = new List<Claim>() {
                new(JwtClaimTypes.Name, "ALFKI")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTime.Now.AddDays(2)
            });
            return CommonTool.CreateApiResult(true);
        }

        [HttpGet]
        public IActionResult LoginByJWT()
        {
            var ui = new JwtUserInfo
            {
                Id = 2,
                UserName = "Customer002",
                NickName = "Customer002"
            };
            var token = JwtHelper.GenerateJsonWebToken(ui);
            return Ok(token);
        }

        [HttpGet]
        public IActionResult LoginBySession()
        {
            var ui = new JwtUserInfo
            {
                Id = 3,
                UserName = "Customer003",
                NickName = "Customer003"
            };
            HttpContext.Session.SetObj(Consts.SessionKey_LoginUser, ui);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
