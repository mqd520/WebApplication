using WebApplication11.DTO;

namespace WebApplication11.Service
{
    public interface IJWTService
    {
        string GetTokenWithModel(JWTUserInfoDTO ui);

        Tuple<string, string> GetTokenWithRefresh(JWTUserInfoDTO ui);

        string GetTokenByRefresh(string refreshToken);
    }
}
