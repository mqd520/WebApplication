using Microsoft.AspNetCore.Mvc;

using WebApplication73.Api.WebApplication24;

namespace WebApplication73.Controllers
{
    public class SampleController : Controller
    {
        private readonly IUserApi _userApi;

        public SampleController(IUserApi userApi)
        {
            _userApi = userApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Sample()
        {
            var ls = await _userApi.GetAllAsync();
            return Json(ls);
        }

        public async Task<IActionResult> Sample2()
        {
            var user = await _userApi.GetByUserIdAsync(1001);
            return Json(user);
        }

        public async Task<IActionResult> Sample3()
        {
            var user = await _userApi.GetByUserNameAsync("Username1002");
            return Json(user);
        }
    }
}
