using Ocelot.Logging;
using Ocelot.Middleware;

namespace WebApplication40.Middlewares
{
    public class RemoveHttpHeaderMiddleware : OcelotMiddleware
    {
        private readonly RequestDelegate _next;

        public RemoveHttpHeaderMiddleware(RequestDelegate next
            , IOcelotLoggerFactory loggerFactory)
            : base(loggerFactory.CreateLogger<RemoveHttpHeaderMiddleware>())
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var downstreamRequest = httpContext.Items.DownstreamRequest();
            downstreamRequest.Headers.Remove("Authorization");

            await _next.Invoke(httpContext);
        }
    }
}
