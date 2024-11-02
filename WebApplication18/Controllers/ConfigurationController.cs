using System.Text;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using WebApplication18.Options;

namespace WebApplication18.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _configuration.AsEnumerable())
            {
                sb.Append($"{item.Key}: {item.Value} {Environment.NewLine}");
            }
            return new ContentResult { Content = sb.ToString() };
        }

        public IActionResult GetAllowedHosts()
        {
            var value = _configuration["AllowedHosts"];
            return new ContentResult { Content = value };
        }

        public IActionResult GetUserInfoOptions()
        {
            var options = _configuration.GetSection(UserInfoOptions.SectionName)
                            .Get<UserInfoOptions>();
            var json = JsonConvert.SerializeObject(options);
            return new ContentResult { Content = json };
        }

        public IActionResult GetUserInfoOptionsAttr()
        {
            var text = _configuration["UserInfo:UserName"];
            return new ContentResult { Content = text };
        }

        public IActionResult GetUserInfoOptionsAttr2()
        {
            var options = _configuration.GetSection(UserInfoOptions.SectionName)
                            .GetValue<UserExtraInfoOptions>("UserExtraInfo");
            var json = JsonConvert.SerializeObject(options);
            return new ContentResult { Content = json };
        }

        public IActionResult GetLogLevel()
        {
            var level = _configuration.GetSection("Logging:LogLevel");
            StringBuilder sb = new StringBuilder();
            foreach (var item in level.GetChildren())
            {
                sb.Append($"{item.Key}: {item.Value} {Environment.NewLine}");
            }
            return new ContentResult { Content = sb.ToString() };
        }

        public IActionResult GetUserExtraInfoOptions()
        {
            var options = _configuration.GetSection(UserExtraInfoOptions.SectionName)
                            .Get<UserExtraInfoOptions>();
            var json = JsonConvert.SerializeObject(options);
            return new ContentResult { Content = json };
        }

        public IActionResult GetUserExtraInfoOptionsAttr()
        {
            var options = _configuration.GetSection(UserExtraInfoOptions.SectionName)
                            .Get<UserExtraInfoOptions>();
            var json = JsonConvert.SerializeObject(options);
            return new ContentResult { Content = json };
        }

        public IActionResult GetInteger()
        {
            var value = _configuration.GetValue<int>("Integer", 20);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetInteger2()
        {
            var value = _configuration.GetValue<int>("Integer2", 20);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetString()
        {
            var value = _configuration.GetValue<string>("String", "defaultStringValue");
            return new ContentResult { Content = value };
        }

        public IActionResult GetString2()
        {
            var value = _configuration.GetValue<string>("String2", "defaultStringValue");
            return new ContentResult { Content = value };
        }

        public IActionResult GetBoolean()
        {
            var value = _configuration.GetValue<bool>("Boolean", false);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetBoolean2()
        {
            var value = _configuration.GetValue<bool>("Boolean2", false);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetFloat()
        {
            var value = _configuration.GetValue<float>("Float");
            return new ContentResult { Content = value.ToString() };
        }
    }
}
