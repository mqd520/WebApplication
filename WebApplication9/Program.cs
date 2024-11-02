using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApplication9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.Cookie.Name = ".auth.cookie";
                options.Cookie.HttpOnly = true;
                //options.ExpireTimeSpan = TimeSpan.FromMilliseconds(10);
                options.LoginPath = "/Account";
                options.LogoutPath = "/Home/Logout";
                options.AccessDeniedPath = "/Forbidden";
                options.SlidingExpiration = true;
                //options.Events.OnSignedIn = context =>
                //{
                //    Console.WriteLine($"{context.Principal.Identity.Name} ÕýÔÚµÇÂ¼...");
                //    return Task.CompletedTask;
                //};
                //options.Events.OnRedirectToLogin = context =>
                //{
                //    Console.WriteLine("OnRedirectToLogin");
                //    return Task.CompletedTask;
                //};
                //options.Events.OnRedirectToLogout = context =>
                //{
                //    Console.WriteLine("OnRedirectToLogout");
                //    return Task.CompletedTask;
                //};
                //options.Events.OnValidatePrincipal = context =>
                //{
                //    Console.WriteLine("OnValidatePrincipal");
                //    return Task.CompletedTask;
                //};
            });

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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
