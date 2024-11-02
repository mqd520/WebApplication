using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication8.Db.Entity;
using WebApplication8.Def;
using WebApplication8.DTO;
using WebApplication8.Filters;

namespace WebApplication8.Controllers
{
    [AllowAnonymous]
    [CheckRepeatLoginAuthorizationFilter]
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInfoDTO dto)
        {
            if (dto.Username.Equals("admin") && dto.Password.Equals("123456"))
            {
                var text = JsonConvert.SerializeObject(new UserInfoEntity
                {
                    Username = "admin",
                    Name = "Administrator",
                    Id = 10001
                });
                HttpContext.Session.SetString(Consts.SESSION_KEY_LOGINUSERINFO, text);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
