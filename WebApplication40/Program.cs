using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

using WebApplication40.ApplicationBuilderExtensions;

namespace WebApplication40
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  

            builder.Services.AddControllers();

            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: false);
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("ProductApiKey", options =>
            {
                options.Authority = "http://localhost:6001/";
                options.Audience = "api";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });
            builder.Services.AddOcelot();

            var app = builder.Build();

            // Configure the HTTP request pipeline.  

            app.UseOcelot((app, config) =>
            {
                app.UseCustomOcelot(config);
            }).Wait();

            app.MapControllers();

            app.Run();
        }
    }
}
