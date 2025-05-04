using FreeRedis;

using Microsoft.AspNetCore.Mvc;

namespace WebApplication53.Controllers
{
    public class RedisController : Controller
    {
        private readonly IRedisClient _redisClient;

        public RedisController(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SetString()
        {
            var value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            await _redisClient.SetAsync<string>("StringKey3", value);
            return Content(value);
        }

        public async Task<IActionResult> GetString()
        {
            var result = await _redisClient.GetAsync<string>("StringKey3");
            return Content(result);
        }
    }
}
