using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Controllers
{
    public class ActionController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult { Content = "Index" };
        }
    }
}
