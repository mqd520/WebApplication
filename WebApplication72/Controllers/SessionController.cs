using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication72.Authentication;
using WebApplication72.Common;
using WebApplication72.Def;

namespace WebApplication72.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class SessionController : Controller
    {
        [HttpGet]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            return Ok("Clear");
        }

        [HttpGet]
        public IActionResult Remove(string key)
        {
            HttpContext.Session.Remove(key);
            return Ok("Remove");
        }

        [HttpGet]
        public IActionResult GetSessionId()
        {
            string id = HttpContext.Session.Id;
            return Ok(id);
        }

        [HttpGet]
        public IActionResult GetKeys()
        {
            var keys = string.Join(',', HttpContext.Session.Keys);
            return Ok(keys);
        }

        [HttpGet]
        public IActionResult SetInt32()
        {
            int value = 32;
            HttpContext.Session.SetInt32("Int32", value);
            return Ok(value);
        }

        [HttpGet]
        public IActionResult GetInt32()
        {
            int? value = HttpContext.Session.GetInt32("Int32");
            return Ok(value);
        }

        [HttpGet]
        public IActionResult SetString()
        {
            string value = "String";
            HttpContext.Session.SetString("String", value);
            return Ok(value);
        }

        [HttpGet]
        public IActionResult GetString()
        {
            string? value = HttpContext.Session.GetString("String");
            return Ok(value);
        }

        [HttpGet]
        public IActionResult SetLoginInfo()
        {
            var ui = new JwtUserInfo
            {
                Id = 1,
                UserName = "UserName001",
                NickName = "NickName001"
            };
            HttpContext.Session.SetObj("LoginInfo", ui);
            return Ok("OK");
        }

        [HttpGet]
        public IActionResult GetLoginInfo()
        {
            var obj = HttpContext.Session.GetObj<JwtUserInfo>("LoginInfo");
            return Json(obj);
        }
    }
}
