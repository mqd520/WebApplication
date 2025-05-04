using StackExchange.Redis;

using WebApplication51.Options;
using WebApplication51.Redis;

namespace WebApplication51
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var redisOptions = builder.Configuration.GetSection(RedisOptions.SectionName).Get<RedisOptions>();
            var config = new ConfigurationOptions();
            config.ServiceName = "mymaster";
            config.EndPoints.Add("192.168.44.14", 26379);
            config.EndPoints.Add("192.168.44.14", 26380);
            config.EndPoints.Add("192.168.44.14", 26381);
            config.TieBreaker = "";
            config.AbortOnConnectFail = false;
            config.AllowAdmin = true;
            //config.CommandMap = CommandMap.Sentinel;
            config.DefaultVersion = new Version(3, 0);
            using var sw = new StreamWriter(Console.OpenStandardOutput());
            var connectionMultiplexer = ConnectionMultiplexer.Connect(config, sw);
            builder.Services.AddSingleton<IConnectionMultiplexer>(connectionMultiplexer);
            builder.Services.AddSingleton<IRedisClient, RedisClient>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
