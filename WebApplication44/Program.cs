namespace WebApplication44
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Logging.AddDebug();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.Lifetime.ApplicationStarted.Register(() =>
            {
                app.Logger.LogInformation("ApplicationStarted!");
            });
            app.Lifetime.ApplicationStopping.Register(() =>
            {
                app.Logger.LogInformation("ApplicationStopping!");
            });
            app.Lifetime.ApplicationStopped.Register(() =>
            {
                app.Logger.LogInformation("ApplicationStopped!");
            });

            app.MapControllers();

            app.Run();
        }
    }
}
