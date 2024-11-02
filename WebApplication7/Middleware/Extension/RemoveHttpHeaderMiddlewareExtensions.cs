namespace WebApplication7.Middleware.Extension
{
    public static class RemoveHttpHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseRemoveHttpHeader(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RemoveHttpHeaderMiddleware>();
        }
    }
}
