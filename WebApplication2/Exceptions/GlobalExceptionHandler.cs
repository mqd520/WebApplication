using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication2.Exceptions
{
    public class GlobalExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task HandleAllExceptions(HttpContext context, Func<Task> next)
        {
            var exceptionDetails = context.Features.Get<IExceptionHandlerFeature>();
            var ex = exceptionDetails?.Error;
            _logger.LogError(ex, "GlobalExceptionHandler.HandleAllExceptions");

            if (ex is not null)
            {
                if (ex is CustomBusinessException)
                {
                    await HandleCustomBusinessException(context, next, ex);
                }
                else
                {
                    await HandleException(context, next, ex);
                }
            }
            else
            {
                await HandleException(context, next, default);
            }
        }

        private async Task HandleException(HttpContext context
            , Func<Task> next
            , Exception? ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync("Server Error!");
        }

        private async Task HandleCustomBusinessException(HttpContext context
            , Func<Task> next
            , Exception? ex)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json;charset=utf-8";
            await context.Response.WriteAsync("Server Error!");
        }
    }
}
