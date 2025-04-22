using Refit;

using WebApplication46.Api.WebApplication24.Def;

namespace WebApplication46.Api.WebApplication24
{
    public interface IUserApi
    {
        [Get("/api/user")]
        Task<IList<UserInfoEntity>> GetAll();

        [Get("/api/user/{userId}")]
        Task<UserInfoEntity> GetByUserId(int userId);

        [Get("/api/user/username/{username}")]
        Task<UserInfoEntity> GetByUserName(string username);
    }
}
