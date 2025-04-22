using Microsoft.IdentityModel.Tokens;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

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
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "http://localhost:5011/";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "api";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            builder.Services.AddOcelot();



            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseOcelot().Wait();

            app.MapControllers();

            app.Run();
        }
    }
}
