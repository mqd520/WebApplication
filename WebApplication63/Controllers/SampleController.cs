using Microsoft.AspNetCore.Mvc;

namespace WebApplication63.Controllers
{
    [ApiController]
    [Route("~/api/[Controller]")]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }

        [HttpGet]
        [Route("{id}")]
        public string GetById(int id)
        {
            return $"Hello World! {id}";
        }
    }
}
