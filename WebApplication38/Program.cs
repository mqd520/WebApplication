namespace WebApplication38
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

            app.MapControllers();

            //app.UseJwtBearerParser();

            app.MapGet("/", () => "Product Api");

            app.Run();
        }
    }
}
