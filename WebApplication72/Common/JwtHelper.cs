using IdentityModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using SqlSugar;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication72.Def;

namespace WebApplication72.Common
{
    public class JwtHelper
    {
        public static string GenerateJsonWebToken(JwtUserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Consts.JWT_Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            claimsIdentity.AddClaim(new Claim(JwtClaimTypes.Id, userInfo.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(JwtClaimTypes.Name, userInfo.UserName));
            claimsIdentity.AddClaim(new Claim(JwtClaimTypes.NickName, userInfo.NickName));
            var token = new JwtSecurityToken(Consts.JWT_Issuer,
                Consts.JWT_Audience,
                claimsIdentity.Claims,
                expires: DateTime.Now.AddMinutes(Consts.JWT_AccessExpiration),
                signingCredentials: credentials
            );
            var tokenText = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenText;
        }

        public static JwtUserInfo ParseFromJsonWebToken(string text)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(text);

            return new JwtUserInfo();
        }
    }
}
