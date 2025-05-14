using Microsoft.AspNetCore.Builder;
using WebApplication72.Middleware;

namespace WebApplication72.ApplicationBuilderExtension
{
    public static class RemoveHttpHeaderExtension
    {
        public static IApplicationBuilder UseRemoveHttpHeader(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RemoveHttpHeaderMiddleware>();
        }
    }
}
