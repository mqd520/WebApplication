using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using Newtonsoft.Json;

using WebApplication2.Def;
using WebApplication2.Exceptions;

namespace WebApplication2.Filters
{
    public class CustomControllerExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<CustomControllerExceptionFilter> _logger;

        public CustomControllerExceptionFilter(ILogger<CustomControllerExceptionFilter> logger)
        {
            _logger = logger;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "CustomControllerExceptionFilter OnExceptionAsync");

            if (context.ExceptionHandled == false)
            {
                if (context.Exception is CustomBusinessException)
                {
                    context.ExceptionHandled = true;
                    var ex2 = (CustomBusinessException)context.Exception;
                    var data = CustomReturnResult.Fail(ex2.ErrorCode, null);
                    var json = JsonConvert.SerializeObject(data);

                    context.Result = new ContentResult
                    {
                        Content = json,
                        ContentType = "application/json;charset=utf-8",
                        StatusCode = 200
                    };
                }
                else
                {
                    context.ExceptionHandled = false;
                }
            }
            return Task.CompletedTask;
        }
    }
}
