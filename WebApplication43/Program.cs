using Consul.AspNetCore;

using WebApplication43.Consul;
using WebApplication43.Options;

namespace WebApplication43
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var consulOption = builder.Configuration.GetSection("Consul").Get<ConsulOption>()!;
            builder.Services.AddConsul(config =>
            {
                config.Address = new Uri(consulOption.Address);
            });
            builder.Services.AddSingleton<IConsulServiceManager, DefaultConsulServiceManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.MapControllers();

            app.Run();
        }
    }
}
