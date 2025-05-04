using ServiceStack.Redis;

namespace WebApplication52
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var hosts = new string[] { "192.168.44.13:26379", "192.168.44.13:26380", "192.168.44.13:26381" };
            var sentinel = new RedisSentinel(hosts, "mymaster")
            {
                IpAddressMap = {
                    { "172.27.0.1", "192.168.44.13" }
                    ,{ "172.27.0.2", "192.168.44.13" }
                    ,{ "172.27.0.3", "192.168.44.13" }
                    ,{ "172.27.0.4", "192.168.44.13" }
                }
            };
            var redisManager = sentinel.Start();
            builder.Services.AddSingleton<IRedisClientsManager>(redisManager);
            builder.Services.AddSingleton<IRedisSentinel>(sentinel);

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
