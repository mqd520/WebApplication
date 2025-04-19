using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using WebApplication11.Options;
using WebApplication11.Service;
using WebApplication11.Services.Implements;

namespace WebApplication11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IJWTService, JWTService>();
            builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection(JWTOptions.Section));
            var jwtOptions = builder.Configuration.GetSection(JWTOptions.Section).Get<JWTOptions>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = jwtOptions?.Audience ?? "",
                    ValidIssuer = jwtOptions?.Issuer ?? "",
                    ClockSkew = TimeSpan.FromSeconds(60),
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions?.SecurityKey ?? ""))
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = async (context) =>
                    {
                        Console.WriteLine("OnAuthenticationFailed");
                        Console.WriteLine(context.Exception.Message);
                        await Task.CompletedTask;
                    },
                    OnTokenValidated = async (context) =>
                    {
                        Console.WriteLine("OnTokenValidated");
                        await Task.CompletedTask;
                    },
                    OnForbidden = async (context) =>
                    {
                        Console.WriteLine("OnForbidden");
                        await Task.CompletedTask;
                    },
                    OnChallenge = async (context) =>
                    {
                        context.HandleResponse();
                        if (!context.Response.HasStarted)
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync("401");
                        }
                        await Task.CompletedTask;
                    },
                    OnMessageReceived = async (context) =>
                    {
                        if (context.Request.Headers.ContainsKey("Authorization"))
                        {
                            context.Token = string.Format("Bearer: {0}", context.Request.Headers["Authorization"].ToString());
                        }
                        else if (context.Request.Cookies.ContainsKey(".aspnetcore.jwt"))
                        {
                            var value = context.Request.Cookies[".aspnetcore.jwt"];
                            Console.WriteLine(value);
                            context.Token = value;
                        }
                        await Task.CompletedTask;
                    }
                };
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
