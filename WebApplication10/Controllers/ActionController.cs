using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Controllers
{
    public class ActionController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult { Content = "Index" };
        }

        public ActionResult<string> Demo()
        {
            return new ActionResult<string>("Demo");
        }

        public ActionResult<string> Demo2()
        {
            return "Demo2";
        }

        public string Demo4()
        {
            return "Demo4";
        }
    }
}
