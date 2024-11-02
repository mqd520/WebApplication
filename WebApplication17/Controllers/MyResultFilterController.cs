using Microsoft.AspNetCore.Mvc;

using WebApplication17.Filters;

namespace WebApplication17.Controllers
{
    [TypeFilter(typeof(MyResultFilter))]
    public class MyResultFilterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
