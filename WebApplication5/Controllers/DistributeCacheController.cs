using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace WebApplication5.Controllers
{
    public class DistributeCacheController : Controller
    {
        private readonly IDistributedCache _cache;

        public DistributeCacheController(IDistributedCache cache)
        {
            _cache = cache;
        }

        public IActionResult SetString()
        {
            var text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            _cache.SetString("String", text);
            return new ContentResult { Content = text };
        }

        public IActionResult GetString()
        {
            var text = _cache.GetString("String");
            return new ContentResult { Content = text };
        }
    }
}
