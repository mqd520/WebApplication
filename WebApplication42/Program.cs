using WebApplication42.ServiceCollectionExtensions;

namespace WebApplication42
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.RegisterConsul(app.Configuration, app.Lifetime);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
