using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication11.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult GetUserInfo()
        {
            var identity = (ClaimsIdentity?)HttpContext.User.Identity;
            var text = JsonConvert.SerializeObject(identity?.Claims ?? [], new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return new JsonResult(identity?.Claims ?? null);
        }
    }
}
