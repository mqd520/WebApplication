using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication9.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult GetUserInfo()
        {
            var idenetity = (ClaimsIdentity?)HttpContext.User.Identity;
            var ls = idenetity?.Claims.Select(x => new { Name = x.ValueType, Value = x.Value }).ToList();
            var text = JsonConvert.SerializeObject(ls);
            return Ok(text);
        }
    }
}
