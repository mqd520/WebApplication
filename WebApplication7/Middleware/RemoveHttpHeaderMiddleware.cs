using System.Diagnostics;

namespace WebApplication7.Middleware
{
    public class RemoveHttpHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RemoveHttpHeaderMiddleware> _logger;

        public RemoveHttpHeaderMiddleware(RequestDelegate next
            , ILogger<RemoveHttpHeaderMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Response.HasStarted)
            {
                context.Response.Headers["Custom-Header"] = "CustomValue";
            }

            await _next(context);

            if (!context.Response.HasStarted)
            {
                context.Response.Headers.Remove("Server");
            }
        }
    }
}
