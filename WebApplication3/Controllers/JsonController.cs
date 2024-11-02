using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Linq;

using WebApplication3.Def;

namespace WebApplication3.Controllers
{
    public class JsonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return new JsonResult(new { Id = 1001, Name = "1001" })
            {
                StatusCode = 200,
                ContentType = "application/json;charset=utf-8"
            };
        }

        public IActionResult Index3()
        {
            return new JsonResult(new { Id = 1001, Time = DateTime.Now })
            {
                StatusCode = 200,
                ContentType = "application/json;charset=utf-8"
            };
        }

        public IActionResult Index4()
        {
            return new JsonResult(new JsonResultData
            {
                Id = 1001,
                Name = "1001",
                Time = DateTime.Now,
                UserInfo = null,
                Ignore = 1,
                Success = true
            })
            {
                StatusCode = 200,
                ContentType = "application/json;charset=utf-8"
            };
        }

        public IActionResult Index5()
        {
            return new JsonResult(new JsonResultData
            {
                Id = 1001,
                Name = "1001",
                Time = DateTime.Now,
                UserInfo = null,
                Ignore = 1,
                Success = true
            })
            {
                StatusCode = 200,
                ContentType = "application/json;charset=utf-8"
            };
        }

        public IActionResult Index6()
        {
            var obj = new JObject {
                new JProperty("String", "String001")
                ,new JProperty("Integer", 1001)
                ,new JProperty("Boolean",true)
                , new JProperty("Data", new JObject{
                    new JProperty("String2","String002")
                    ,new JProperty("Integer2", 1002)
                })
            };
            return new JsonResult(obj);
        }
    }
}
