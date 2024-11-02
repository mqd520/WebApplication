using Microsoft.AspNetCore.Mvc;

using WebApplication22.DTO;

namespace WebApplication22.Controllers
{
    public class ModelBindController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2(UserInfoDTO ui)
        {
            return View(ui);
        }

        public IActionResult Index3(UserInfo2DTO ui)
        {
            return View(ui);
        }
    }
}
