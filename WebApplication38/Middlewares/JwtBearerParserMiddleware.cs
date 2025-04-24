using System.Security.Claims;

using WebApplication38.Def;
using WebApplication38.Tools;

namespace WebApplication38.Middlewares
{
    public class JwtBearerParserMiddleware
    {
        private readonly ILogger<JwtBearerParserMiddleware> _logger;
        private readonly RequestDelegate _next;

        public JwtBearerParserMiddleware(ILogger<JwtBearerParserMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authorization = context.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authorization)
                || !authorization.StartsWith("Bearer "))
            {
                _logger.LogWarning("Authorization header is missing.");
            }
            else
            {
                var token = authorization.Substring(7);
                if (string.IsNullOrEmpty(token))
                {
                    _logger.LogWarning("Bearer data is missing.");
                }
                else
                {
                    JwtInfo jwt = new();
                    var parseSuccessFlag = false;
                    try
                    {
                        jwt = JwtHelper.Parse(token);
                        parseSuccessFlag = true;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Parse Jwt Failed");
                    }

                    if (parseSuccessFlag)
                    {
                        var identity = new ClaimsIdentity();
                        identity.AddClaims(
                        [
                            new Claim("Aud", jwt.Payload.Aud),
                            new Claim("ClientId", jwt.Payload.ClientId),
                            new Claim("Iss", jwt.Payload.Iss)
                        ]);
                        //context.User.AddIdentity(identity);
                    }
                }
            }

            await _next(context);
        }
    }
}
