using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication8.Def;

namespace WebApplication8.Filters
{
    public class CheckRepeatLoginAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Session.GetString(Consts.SESSION_KEY_LOGINUSERINFO);
            if (user != null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
