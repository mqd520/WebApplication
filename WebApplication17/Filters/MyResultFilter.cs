using System.Text;

using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication17.Filters
{
    public class MyResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in context.HttpContext.Response.Headers)
            {
                sb.Append($"{item.Key}: {item.Value.ToString()}{Environment.NewLine}");
            }
            context.HttpContext.Response.WriteAsync(sb.ToString());
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {

        }
    }
}
