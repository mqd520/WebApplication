using Microsoft.AspNetCore.Mvc;

using WebApplication24.Db;
using WebApplication24.Db.Entity;

namespace WebApplication24.Controllers
{
    [ApiController]
    [Route("~/api/[Controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IList<UserInfoEntity> GetAllUsers()
        {
            return UserHelper.Users;
        }

        [HttpGet("{userId:int}")]
        public UserInfoEntity GetByUserId(int userId)
        {
            return UserHelper.Users.Where(x => x.Id == userId).FirstOrDefault()!;
        }

        [HttpGet("{username}")]
        public UserInfoEntity GetByUserName(string username)
        {
            return UserHelper.Users.Where(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)).FirstOrDefault()!;
        }
    }
}
