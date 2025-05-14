namespace WebApplication72.Middleware
{
    public class RemoveHttpHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly static string[] Headers = new string[] {
            "x-powered-by",
            "server"
        };

        public RemoveHttpHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //context.Response.OnStarting(() =>
            //{
            //    var dict = context.Response.Headers;
            //    foreach (var item in Headers)
            //    {
            //        if (dict.ContainsKey(item))
            //        {
            //            dict.Remove(item);
            //        }
            //    }

            //    return Task.CompletedTask;
            //});

            context.Response.Headers.Remove("server");
            context.Response.Headers.Remove("x-powered-by");

            await _next(context);

            context.Response.Headers.Remove("server");
            context.Response.Headers.Remove("x-powered-by");
        }
    }
}
