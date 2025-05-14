using WebApiClientCore;
using WebApiClientCore.Attributes;

using WebApplication73.Def;

namespace WebApplication73.Api.WebApplication24
{
    public interface IUserApi : IHttpApi
    {
        [HttpGet("/api/user")]
        Task<IList<UserInfo>> GetAllAsync();

        [HttpGet("/api/user/{userId}")]
        Task<UserInfo> GetByUserIdAsync(int userId);

        [HttpGet("/api/user/username/{username}")]
        Task<UserInfo> GetByUserNameAsync(string username);
    }
}
