using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using WebApplication72.Common;
using WebApplication72.Def;

namespace WebApplication72.Filter
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ILogger<CustomAuthorizationFilterAttribute> _logger;

        public CustomAuthorizationFilterAttribute(ILogger<CustomAuthorizationFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsSkipAuthenticate(context))
            {
                JwtUserInfo? ui = null;
                try
                {
                    ui = context.HttpContext.Session.GetObj<JwtUserInfo>(Consts.SessionKey_LoginUser);
                }
                catch (Exception ex)
                {
                    _logger.LogError(message: "CustomAuthorizationFilter Error", exception: ex);
                }

                if (ui == null)
                {
                    var sessionId = context.HttpContext.Session.Id;
                    _logger.LogError(message: $"Validate Session Fail, SessionId: {sessionId}");

                    context.Result = new ContentResult
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Content = "401",
                        ContentType = "text/plain"
                    };
                }
                else
                {
                    var claims = new Claim[] {
                        new Claim(JwtClaimTypes.Name,ui.UserName),
                        new Claim(JwtClaimTypes.NickName,ui.UserName),
                        new Claim(JwtClaimTypes.Id,ui.Id.ToString()),
                    };
                    var identity = new ClaimsIdentity(claims);
                    var principal = new ClaimsPrincipal(identity);
                    context.HttpContext.User = principal;
                }
            }
        }

        protected bool IsSkipAuthenticate(AuthorizationFilterContext context)
        {
            if (context.Filters.Count(x => x.GetType() == typeof(CustomAllowAnonymousFilterAttribute)) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
