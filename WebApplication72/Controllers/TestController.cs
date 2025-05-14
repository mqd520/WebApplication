using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using WebApplication72.Autofac;
using WebApplication72.Db.Entity;
using WebApplication72.Db.Repository;

namespace WebApplication72.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region Property
        [CustomPropertySelector]
        private IConfiguration Configuration { get; set; }

        [CustomPropertySelector]
        private ILogger<TestController> Logger { get; set; }

        [CustomPropertySelector]
        private IServiceProvider ServiceProvider { get; set; }

        [CustomPropertySelector]
        private IWebHostEnvironment WebHostEnvironment { get; set; }

        [CustomPropertySelector]
        private IHostApplicationLifetime ApplicationLifetime { get; set; }

        [CustomPropertySelector]
        private ICollection<string> Urls { get; set; }

        [CustomPropertySelector]
        private ICategoryRepository CategoryRepository { get; set; }
        #endregion

        [HttpGet]
        public ContentResult Test([FromServices] IConfiguration configuration)
        {
            return new ContentResult
            {
                Content = "200",
                ContentType = "text/plain",
                StatusCode = 200
            };
        }
    }
}
