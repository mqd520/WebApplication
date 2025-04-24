using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication38.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private IServer _server;

        public ProductController(IServer server)
        {
            _server = server;
        }

        [HttpGet]
        [Route("info")]
        public ActionResult<string> GetServerInfo()
        {
            var serverAddressesFeature = _server.Features.Get<IServerAddressesFeature>();
            var url = serverAddressesFeature?.Addresses.First() ?? "";
            return $"Product: {url}";
        }

        [HttpGet]
        [Route("authorization")]
        public ActionResult<string> GetAuthorization()
        {
            return Content(Request.Headers["Authorization"].ToString());
        }

        [HttpGet]
        [Route("principal")]
        public ActionResult<string> GetPrincipal()
        {
            var user = Request.HttpContext.User;
            var identity = Request.HttpContext.User.Identity;
            return Content("ok");
        }

        [HttpGet]
        [Route("iss")]
        public ActionResult<string> GetIss()
        {
            var iss = Request.Headers["iss"].ToString();
            return Content(iss);
        }

        [HttpGet]
        [Route("aud")]
        public ActionResult<string> GetAud()
        {
            var iss = Request.Headers["aud"].ToString();
            return Content(iss);
        }
    }
}
