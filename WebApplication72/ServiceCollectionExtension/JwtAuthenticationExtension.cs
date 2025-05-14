using log4net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApplication72.Config;
using WebApplication72.Def;

namespace WebApplication72.ServiceCollectionExtension
{
    public static class JwtAuthenticationExtension
    {
        private static ILogger? _logger;

        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            if (_logger == null)
            {
                var provider = services.BuildServiceProvider();
                var factory = provider.GetService<ILoggerFactory>();
                if (factory != null)
                {
                    _logger = factory.CreateLogger(typeof(JwtAuthenticationExtension).Name);
                }
            }

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var buf = Encoding.UTF8.GetBytes(MyConfig.JwtOptions.Key);
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = MyConfig.JwtOptions.Issuer,
                    ValidAudience = MyConfig.JwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(buf),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.FromSeconds(30)  // 对token过期时间验证的允许时间
                };
                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        var token = context.Request.Headers["Authorization"];
                        _logger?.LogError($"Validate Jwt Fail: {token}");
                        var data = new ApiResultData
                        {
                            Success = false,
                            Msg = "Invalid Jwt"
                        };
                        var text = JsonConvert.SerializeObject(data);
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return context.Response.WriteAsync(text);
                    }
                };
            });
        }
    }
}
