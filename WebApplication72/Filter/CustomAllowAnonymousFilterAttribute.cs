using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication72.Filter
{
    public class CustomAllowAnonymousFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
