using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication19.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Request.Path.Value.Equals("/SimulateHttpStatusCode/HttpStatusCode401"))
            {
                context.HttpContext.Response.ContentType = "hhhhhhh";
            }
        }
    }
}
