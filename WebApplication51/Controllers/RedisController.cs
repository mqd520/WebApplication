using Microsoft.AspNetCore.Mvc;

using WebApplication51.Redis;

namespace WebApplication51.Controllers
{
    public class RedisController : Controller
    {
        private readonly IRedisClient _redis;

        public RedisController(IRedisClient redis)
        {
            _redis = redis;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SetStringAsync()
        {
            var value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            var result = await _redis.SetStringAsync("StringKey2", value);
            return Content(result.ToString());
        }

        [HttpGet]
        public async Task<IActionResult> GetStringAsync()
        {
            var result = await _redis.GetStringAsync("StringKey2");
            return Content(result);
        }
    }
}
