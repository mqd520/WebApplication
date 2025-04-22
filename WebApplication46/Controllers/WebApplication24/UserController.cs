using Microsoft.AspNetCore.Mvc;

using WebApplication46.Api.WebApplication24;
using WebApplication46.Api.WebApplication24.Def;

namespace WebApplication46.Controllers.WebApplication24
{
    public class UserController : Controller
    {
        private IUserApi _userApi;

        public UserController(IUserApi userApi)
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

        public async Task<UserInfoEntity> GetByUserId(int userId)
        {
            var result = await _userApi.GetByUserId(userId);
            return result;
        }

        public async Task<UserInfoEntity> GetByUserName(string username)
        {
            var result = await _userApi.GetByUserName(username);
            return result;
        }
    }
}
