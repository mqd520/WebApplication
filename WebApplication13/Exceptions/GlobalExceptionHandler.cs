﻿using Microsoft.AspNetCore.Diagnostics;

namespace WebApplication13.Exceptions
{
    public class GlobalExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task ExceptionHandler(HttpContext context, Func<Task> next)
        {
            var exceptionDetails = context.Features.Get<IExceptionHandlerFeature>();
            var ex = exceptionDetails?.Error;
            _logger.LogError(ex, "GlobalExceptionHandler.ExceptionHandler");

            if (ex is not null)
            {
                if (ex is ValidationFailureException exception)
                {
                    await HandleValidationFailureException(context, exception);
                }
                else
                {
                    await HandleSystemException(context, ex);
                }
            }
            else
            {
                await HandleSystemException(context, default);
            }
        }

        private async Task HandleValidationFailureException(HttpContext context
            , ValidationFailureException? ex)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync(ex?.Message ?? "");
        }

        private async Task HandleSystemException(HttpContext context, Exception? ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync("Server Error!");
        }
    }
}
