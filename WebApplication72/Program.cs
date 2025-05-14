using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

using WebApplication72.Authentication;
using WebApplication72.Autofac;
using WebApplication72.Config;
using WebApplication72.Filter;
using WebApplication72.ServiceCollectionExtension;

namespace WebApplication72
{
    public class Program
    {
        public static WebApplicationBuilder WebApplicationBuilder { get; private set; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            MyConfig.Init(builder);

            AutofacConfig.Init(builder);

            builder.Logging.ClearProviders();
            builder.Logging.AddLog4Net();

            builder.Services.AddSqlSugar();

            builder.Services.AddControllers();
            builder.Services.Configure<MvcOptions>(opts =>
            {
                opts.Filters.Add<CustomExceptionFilterAttribute>();
                //opts.Filters.Add<CustomAuthorizationFilterAttribute>();
            });

            builder.Services.AddSwagger();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = SessionAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = SessionAuthenticationDefaults.AuthenticationScheme;
                options.AddScheme<SessionAuthenticationHandler>(
                    SessionAuthenticationDefaults.AuthenticationScheme
                    , SessionAuthenticationDefaults.AuthenticationScheme);
            });

            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = MyConfig.RedisOptions.Connection;
                options.InstanceName = MyConfig.RedisOptions.InstanceName;
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(MyConfig.SessionOptions.Timeout);
                options.Cookie.Name = MyConfig.SessionOptions.CookieName;
                options.Cookie.HttpOnly = true;
            });

            builder.Services.AddHttpLogging(options =>
            {
                options.LoggingFields = HttpLoggingFields.All;
                options.CombineLogs = true;
            });

            var app = builder.Build();

            app.UseHttpLogging();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context => await HandleExceptionAsync(context, app.Logger));
                });
            }

            app.UseCors();

            app.UseHttpLogging();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static async Task HandleExceptionAsync(HttpContext context, ILogger logger)
        {
            var feature = context.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;
            logger.LogCritical(exception: error, message: "Global Exception Handle");

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("500");
        }
    }
}
