using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication19.Filters
{
    public class CustomResultFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.HttpContext.Request.Path == "/SimulateHttpStatusCode/HttpStatusCode401")
            {

            }
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            if (context.HttpContext.Request.Path == "/SimulateHttpStatusCode/HttpStatusCode401")
            {
                context.HttpContext.Response.Headers.Remove("Content-Type");
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            }
        }
    }
}
