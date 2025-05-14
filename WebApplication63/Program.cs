using StackExchange.Profiling.Storage;

namespace WebApplication63
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddMiniProfiler(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("MiniProfileDbConnectionStrings")!;
                options.RouteBasePath = "/profiler";
                var mysqlStorage = new MySqlStorage(connectionString);
                options.Storage = mysqlStorage;
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    options.RoutePrefix = "swagger";
                });

                app.UseMiniProfiler();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
