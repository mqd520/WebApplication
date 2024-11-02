using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication8.Def;

namespace WebApplication8.Filters
{
    public class CheckLoginAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Trace.WriteLine(context.HttpContext.Request.Path);

            var decriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var hasAttr = decriptor.ControllerTypeInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any();
            var hasAttr2 = decriptor.MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any();
            if (!hasAttr && !hasAttr2)
            {
                var user = context.HttpContext.Session.GetString(Consts.SESSION_KEY_LOGINUSERINFO);
                if (user == null)
                {
                    context.Result = new RedirectToActionResult("Index", "Account", null);
                }
            }
        }
    }
}
