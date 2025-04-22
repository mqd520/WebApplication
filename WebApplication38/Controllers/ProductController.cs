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
            return url;
        }
    }
}
