namespace WebApplication59
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddSingleton<ApplicationDbContext>();
            builder.Services.AddCap(options =>
            {
                options.UseMySql("Data Source=192.168.44.10;Database=dotnetcore.cap;User ID=root;Password=123456;Port=3306");
                //options.UseEntityFramework<ApplicationDbContext>();
                options.UseRabbitMQ(options =>
                {
                    options.HostName = "192.168.44.13";
                    options.UserName = "root";
                    options.Password = "123456";
                    options.VirtualHost = "/";
                });
                options.UseDashboard(options =>
                {
                    options.PathMatch = "/cap";
                });
            });

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
