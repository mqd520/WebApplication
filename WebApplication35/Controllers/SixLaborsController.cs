using Microsoft.AspNetCore.Mvc;

using WebApplication35.Common;

namespace WebApplication35.Controllers
{
    public class SixLaborsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sample()
        {
            var (imgBytes, code) = SixLaborsImageHelper.BuildVerifyCode(111, 36, 25, 0);
            return File(imgBytes, "image/jpeg");
        }

        public IActionResult Sample2()
        {
            var (imgBytes, code) = SixLaborsImageHelper.BuildVerifyCode(111, 36, 25, 0);
            var imgString = $"data:image/jpg;base64,{Convert.ToBase64String(imgBytes)}";
            return Ok(imgString);
        }
    }
}
