using Microsoft.AspNetCore.Mvc;

using WebApplication21.Tools;

namespace WebApplication21.Controllers
{
    public class WebRequestToolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IsAjaxRequest()
        {
            var result = WebRequestTool.IsAjaxRequest(Request);
            return new ContentResult { Content = result.ToString() };
        }

        public IActionResult GetRealClientIp()
        {
            var ip = WebRequestTool.GetRealClientIp(Request);
            return new ContentResult { Content = ip };
        }
    }
}
