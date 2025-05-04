using Microsoft.AspNetCore.Mvc;

using WebApplication6.Tools;

namespace WebApplication6.Controllers
{
    public class RedisController : Controller
    {
        private readonly IRedisHelper _redisHelper;

        public RedisController(IRedisHelper redisHelper)
        {
            _redisHelper = redisHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SetStringAsync()
        {
            string value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            await _redisHelper.SetStringAsync("String", value, TimeSpan.FromMinutes(10));
            return Content(value);
        }

        [HttpGet]
        public async Task<IActionResult> GetStringAsync()
        {
            var text = await _redisHelper.GetStringAsync("String");
            return Content(text);
        }
    }
}
