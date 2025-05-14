namespace WebApplication61
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddInject();

            var app = builder.Build().UseDefaultServiceProvider();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.UseInject();

            app.MapControllers();

            app.Run();
        }
    }
}
