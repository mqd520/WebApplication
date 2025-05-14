using Furion.DynamicApiController;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication61.Controllers
{
    [Route("[Controller]")]
    public class SampleController : IDynamicApiController
    {
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetAll()
        {
            return "GetAll";
        }
    }
}
