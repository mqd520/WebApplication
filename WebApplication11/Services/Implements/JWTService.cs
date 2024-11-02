using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApplication11.DTO;
using WebApplication11.Options;
using WebApplication11.Service;

namespace WebApplication11.Services.Implements
{
    public class JWTService : IJWTService
    {
        private static Dictionary<string, JWTUserInfoDTO> TokenCache = [];

        private JWTOptions _jwtOptions;

        public JWTService(IOptions<JWTOptions> options)
        {
            _jwtOptions = options.Value;
        }


        /// <summary>
        /// 刷新token的有效期问题上端校验
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public string GetTokenByRefresh(string refreshToken)
        {
            //refreshToken在有效期，但是缓存可能没有？ 还能去手动清除--比如改密码了，清除缓存，用户来刷新token就发现没有了，需要重新登陆
            if (TokenCache.ContainsKey(refreshToken))
            {
                string token = IssueToken(TokenCache[refreshToken], 1);
                return token;
            }
            else
            {
                return "";
            }
        }

        public Tuple<string, string> GetTokenWithRefresh(JWTUserInfoDTO ui)
        {
            string token = IssueToken(ui, _jwtOptions.ExpireTime);
            string refreshToken = IssueToken(ui, 7 * 24 * 60);
            TokenCache.Add(refreshToken, ui);

            return Tuple.Create(token, refreshToken);
        }


        public string GetTokenWithModel(JWTUserInfoDTO ui)
        {
            return IssueToken(ui, _jwtOptions.ExpireTime);
        }

        private string IssueToken(JWTUserInfoDTO ui, int minutes)
        {
            var claims = new[]
            {
                new Claim("UserName", ui.UserName),
                new Claim("Name",ui.Name),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(minutes),
                notBefore: DateTime.Now,    // 立即生效  DateTime.Now.AddMilliseconds(30),//30s后有效
                signingCredentials: creds);
            string returnToken = new JwtSecurityTokenHandler().WriteToken(token);
            return returnToken;
        }
    }
}
