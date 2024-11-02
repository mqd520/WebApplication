using Microsoft.AspNetCore.Mvc;

namespace WebApplication19.Controllers
{
    public class SimulateHttpStatusCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HttpStatusCode401()
        {
            //return new ContentResult { Content = "401", StatusCode = 401 };
            //return new StatusCodeResult(403);
            if (!Request.QueryString.HasValue)
            {
                throw new Exception("sddd");
            }
            return BadRequest();
        }

        public IActionResult HttpStatusCode403()
        {
            return new ContentResult { Content = "403", StatusCode = 403 };
        }

        public IActionResult HttpStatusCode500()
        {
            return new ContentResult { Content = "500", StatusCode = 500 };
        }

        public IActionResult HttpStatusCode500_2()
        {
            return new ContentResult { Content = "", StatusCode = 500 };
        }
    }
}
