using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication72.Def;

namespace WebApplication72.Filter
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger
            , IWebHostEnvironment WebHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = WebHostEnvironment;
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Custom Exception Handler");

            if (!_webHostEnvironment.IsDevelopment())
            {
                context.ExceptionHandled = true;

                var cr = new ContentResult
                {
                    Content = "500",
                    ContentType = "text/plain",
                    StatusCode = 500
                };
                context.Result = cr;
            }

            return Task.CompletedTask;
        }
    }
}
