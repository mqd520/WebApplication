using Microsoft.AspNetCore.Mvc;

namespace WebApplication19.Controllers
{
    public class HttpStatusCodeController : Controller
    {
        [Route("/error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            //var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCode == (int)StatusCodes.Status404NotFound)
            {
                return Handle404();
            }
            else if (statusCode == (int)StatusCodes.Status401Unauthorized)
            {
                return Handle401();
            }
            else if (statusCode == (int)StatusCodes.Status403Forbidden)
            {
                return Handle403();
            }
            else if (statusCode == (int)StatusCodes.Status500InternalServerError)
            {
                return Handle500();
            }
            else
            {
                return new ContentResult { Content = "error" };
            }
        }

        private IActionResult Handle401()
        {
            return new ContentResult { Content = "401" };
        }

        private IActionResult Handle403()
        {
            return new ContentResult { Content = "403" };
        }

        private IActionResult Handle404()
        {
            return new ContentResult { Content = "404" };
        }

        private IActionResult Handle500()
        {
            return new ContentResult { Content = "500" };
        }
    }
}
