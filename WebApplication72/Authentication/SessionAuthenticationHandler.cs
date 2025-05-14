using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using WebApplication72.Common;
using WebApplication72.Def;

namespace WebApplication72.Authentication
{
    public class SessionAuthenticationHandler
       : AuthenticationHandler<SessionAuthenticationOptions>
    {
        public SessionAuthenticationHandler(
            IOptionsMonitor<SessionAuthenticationOptions> options
            , ILoggerFactory logger
            , UrlEncoder encoder)
            : base(options, logger, encoder)
        {

        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>() != null)
            {
                return await Task.FromResult(AuthenticateResult.NoResult());
            }

            JwtUserInfo? ui = null;
            try
            {
                ui = Context.Session.GetObj<JwtUserInfo>(Consts.SessionKey_LoginUser);
            }
            catch (Exception ex)
            {
                Logger.LogError(message: "HandleAuthenticateAsync Error", exception: ex);
            }

            if (ui == null)
            {
                var result = AuthenticateResult.Fail(new Exception("Not Found Login Session"));
                return await Task.FromResult(result);
            }
            else
            {
                var claims = new Claim[] {
                    new Claim(JwtClaimTypes.Id, ui.Id.ToString()),
                    new Claim(JwtClaimTypes.Name, ui.UserName),
                    new Claim(JwtClaimTypes.NickName, ui.NickName)
                };
                var identity = new ClaimsIdentity(claims
                    , SessionAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal
                    , SessionAuthenticationDefaults.AuthenticationScheme);
                var result = AuthenticateResult.Success(ticket);
                return await Task.FromResult(result);
            }
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            var result = await HandleAuthenticateOnceSafeAsync();

            await base.HandleChallengeAsync(properties);
        }

        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            var result = await HandleAuthenticateOnceSafeAsync();

            await base.HandleForbiddenAsync(properties);
        }
    }
}
