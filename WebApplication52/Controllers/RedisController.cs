using Microsoft.AspNetCore.Mvc;

using ServiceStack.Redis;

namespace WebApplication52.Controllers
{
    public class RedisController : Controller
    {
        private IRedisSentinel _redisSentinel;
        private IRedisClientsManager _redisClientManager;


        public RedisController(IRedisSentinel redisSentinel, IRedisClientsManager redisClientManager)
        {
            _redisSentinel = redisSentinel;
            _redisClientManager = redisClientManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetString()
        {
            var redisClient = _redisClientManager.GetReadOnlyClient();
            var result = redisClient.Get<string>("StringKey");
            return Content(result);
        }
    }
}
