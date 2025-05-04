using Microsoft.AspNetCore.Mvc;

using WebApplication50.DTO;
using WebApplication50.Tools;

namespace WebApplication50.Controllers
{
    public class RedisController : Controller
    {
        private readonly IRedisHelper _redis;

        public RedisController(IRedisHelper redis)
        {
            _redis = redis;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SetString()
        {
            string value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
            _redis.SetString("String", value, TimeSpan.FromMinutes(10));
            return new ContentResult { Content = value };
        }

        [HttpGet]
        public IActionResult GetString()
        {
            var text = _redis.GetString("String");
            return new ContentResult { Content = text ?? "Null" };
        }

        [HttpGet]
        public IActionResult SetInt32()
        {
            string text = DateTime.Now.ToString("HHmmss");
            int value = Convert.ToInt32(text);
            _redis.SetInt32("Int32", value, TimeSpan.FromMinutes(10));
            return new ContentResult { Content = text };
        }

        [HttpGet]
        public IActionResult GetInt32()
        {
            var text = _redis.GetInt32("Int32");
            return new ContentResult { Content = text?.ToString() ?? "null" };
        }

        [HttpGet]
        public IActionResult SetInt16()
        {
            string text = DateTime.Now.ToString("mmss");
            Int16 value = Convert.ToInt16(text);
            _redis.SetInt16("Int16", value, TimeSpan.FromMinutes(10));
            return new ContentResult { Content = text };
        }

        [HttpGet]
        public IActionResult GetInt16()
        {
            var text = _redis.GetInt16("Int16");
            return new ContentResult { Content = text?.ToString() ?? "null" };
        }

        [HttpGet]
        public IActionResult SetInt64()
        {
            string text = DateTime.Now.ToString("yyyyMMddHHmmss");
            Int64 value = Convert.ToInt64(text);
            _redis.SetInt64("Int64", value, TimeSpan.FromMinutes(10));
            return new ContentResult { Content = text };
        }

        [HttpGet]
        public IActionResult GetInt64()
        {
            var text = _redis.GetInt64("Int64");
            return new ContentResult { Content = text?.ToString() ?? "null" };
        }

        [HttpGet]
        public IActionResult SetBoolean()
        {
            bool value = true;
            _redis.SetBoolean("Boolean", value, TimeSpan.FromMinutes(10));
            return new ContentResult { Content = value.ToString() };
        }

        [HttpGet]
        public IActionResult GetBoolean()
        {
            var text = _redis.GetBoolean("Boolean");
            return new ContentResult { Content = text?.ToString() ?? "null" };
        }

        [HttpGet]
        public IActionResult SetFloat()
        {
            string text = DateTime.Now.ToString("mm.ss");
            float value = float.Parse(text);
            _redis.SetFloat("Float", value, TimeSpan.FromMinutes(10));
            return new ContentResult { Content = text };
        }

        [HttpGet]
        public IActionResult GetFloat()
        {
            var text = _redis.GetFloat("Float");
            return new ContentResult { Content = text?.ToString() ?? "null" };
        }

        [HttpGet]
        public IActionResult SetDouble()
        {
            string text = DateTime.Now.ToString("MMdd.HHmmss");
            double value = Convert.ToDouble(text);
            _redis.SetDouble("Double", value, TimeSpan.FromMinutes(10));
            return new ContentResult { Content = text };
        }

        [HttpGet]
        public IActionResult GetDouble()
        {
            var text = _redis.GetDouble("Double");
            return new ContentResult { Content = text?.ToString() ?? "null" };
        }

        [HttpGet]
        public IActionResult SetDecimal()
        {
            string text = DateTime.Now.ToString("yyyyMMdd.HHmmss");
            decimal value = Convert.ToDecimal(text);
            _redis.SetDecimal("Decimal", value, TimeSpan.FromMinutes(10));
            return new ContentResult { Content = text };
        }

        [HttpGet]
        public IActionResult GetDecimal()
        {
            var text = _redis.GetDecimal("Decimal");
            return new ContentResult { Content = text?.ToString() ?? "null" };
        }

        [HttpGet]
        public IActionResult SetDatetime()
        {
            DateTime value = DateTime.Now;
            _redis.SetDatetime("Datetime", value, TimeSpan.FromMinutes(10), "yyyy-MM-dd HH:mm:ss fff");
            return new ContentResult { Content = value.ToString("yyyy-MM-dd HH:mm:ss fff") };
        }

        [HttpGet]
        public IActionResult GetDatetime()
        {
            var text = _redis.GetDatetime("Datetime");
            return new ContentResult { Content = text?.ToString("yyyy-MM-dd HH:mm:ss fff") ?? "null" };
        }

        [HttpGet]
        public IActionResult SetObject()
        {
            var ui = new UserInfoDTO { UserName = "username001", Password = "password001" };
            _redis.SetObject<UserInfoDTO>("UserInfo", ui, TimeSpan.FromMinutes(10));
            return new ContentResult { Content = ui.ToString() };
        }

        [HttpGet]
        public IActionResult GetObject()
        {
            var ui = _redis.GetObject<UserInfoDTO>("UserInfo");
            return new ContentResult { Content = ui?.ToString() ?? "null" };
        }
    }
}
