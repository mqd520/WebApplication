using Microsoft.AspNetCore.Mvc;

namespace WebApplication42.Controllers
{
    [ApiController]
    [Route("~/api/[Controller]")]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public string Test()
        {
            return "Test";
        }
    }
}
