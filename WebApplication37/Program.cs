using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace WebApplication37
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: false);
            builder.Services.AddOcelot();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseOcelot().Wait();

            app.MapControllers();

            app.Run();
        }
    }
}
