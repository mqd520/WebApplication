using Microsoft.AspNetCore.Mvc;
using WebApplication8.Def;

namespace WebApplication8.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSessionId()
        {
            var text = HttpContext.Session.Id;
            return new ContentResult { Content = text };
        }

        public IActionResult GetSessionAllKeys()
        {
            var keys = HttpContext.Session.Keys;
            return new ContentResult { Content = string.Join(", ", keys) };
        }

        public IActionResult GetSessionUserLoginInfo()
        {
            var text = HttpContext.Session.GetString(Consts.SESSION_KEY_LOGINUSERINFO);
            return new ContentResult { Content = text?.ToString() ?? "" };
        }
    }
}
