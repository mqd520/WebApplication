using Microsoft.AspNetCore.Mvc;

using WebApplication46.Api.WebApplication24;
using WebApplication46.Api.WebApplication24.Def;

namespace WebApplication46.Controllers
{
    public class SampleController : Controller
    {
        private IUserApi _userApi;

        public SampleController(IUserApi userApi)
        {
            _userApi = userApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IList<UserInfoEntity>> GetAll()
        {
            var result = await _userApi.GetAll();
            return result;
        }
    }
}
