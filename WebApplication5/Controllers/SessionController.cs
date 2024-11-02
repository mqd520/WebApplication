using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication5.DTO;
using WebApplication5.Extensions;

namespace WebApplication5.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult GetSessionId()
        {
            string text = string.Format("SessionId: {0}", HttpContext.Session.Id);
            return new ContentResult { Content = text };
        }

        public IActionResult GetSessionKeys()
        {
            var ls = HttpContext.Session.Keys;
            return new ContentResult { Content = String.Join(", ", ls) };
        }

        public IActionResult SetSessionAttrString()
        {
            string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            HttpContext.Session.SetString("String", text);
            return new ContentResult { Content = text };
        }

        public IActionResult GetSessionAttrString()
        {
            var text = HttpContext.Session.GetString("String");
            return new ContentResult { Content = text };
        }

        public IActionResult SetSessionAttrInt32()
        {
            string text = DateTime.Now.ToString("yyyyMMdd");
            int value = Convert.ToInt32(text);
            HttpContext.Session.SetInt32("Int32", value);
            return new ContentResult { Content = text };
        }

        public IActionResult GetSessionAttrInt32()
        {
            var value = HttpContext.Session.GetInt32("Int32");
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult SetSessionAttrObject()
        {
            var ui = new UserInfoDTO { UserName = "username001", Password = "password001" };
            string text = JsonConvert.SerializeObject(ui);
            HttpContext.Session.SetString("UserInfo", text);
            return new ContentResult { Content = text };
        }

        public IActionResult GetSessionAttrObject()
        {
            var text = HttpContext.Session.GetString("UserInfo");
            var ui = JsonConvert.DeserializeObject<UserInfoDTO>(text ?? "");
            Debug.WriteLine(ui);
            return new ContentResult { Content = ui?.ToString() ?? "null" };
        }

        public IActionResult SetSessionAttrObject2()
        {
            var ui = new UserInfoDTO { UserName = "username002", Password = "password002" };
            HttpContext.Session.SetObject<UserInfoDTO>("UserInfo", ui);
            return new ContentResult { Content = ui.ToString() };
        }

        public IActionResult GetSessionAttrObject2()
        {
            var ui = HttpContext.Session.GetObject<UserInfoDTO>("UserInfo");
            Debug.WriteLine(ui);
            return new ContentResult { Content = ui?.ToString() ?? "null" };
        }

        public IActionResult GetSessionAttrBoolean()
        {
            var value = HttpContext.Session.GetBoolean("Boolean");
            return new ContentResult { Content = value.ToString() ?? "null" };
        }

        public IActionResult SetSessionAttrBoolean()
        {
            HttpContext.Session.SetBoolean("Boolean", true);
            return new ContentResult { Content = "True" };
        }

        public IActionResult SetSessionAttrBoolean2()
        {
            HttpContext.Session.SetBoolean("Boolean", false);
            return new ContentResult { Content = "False" };
        }

        public IActionResult SetSessionAttrFloat()
        {
            float value = 1.234f;
            HttpContext.Session.SetFloat("Float", value);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetSessionAttrFloat()
        {
            var value = HttpContext.Session.GetFloat("Float");
            return new ContentResult { Content = value.HasValue ? value.ToString() : "null" };
        }

        public IActionResult SetSessionAttrDouble()
        {
            double value = 1.23456789;
            HttpContext.Session.SetDouble("Double", value);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetSessionAttrDouble()
        {
            var value = HttpContext.Session.GetFloat("Double");
            return new ContentResult { Content = value.HasValue ? value.ToString() : "null" };
        }

        public IActionResult SetSessionAttrInt16()
        {
            Int16 value = 123;
            HttpContext.Session.SetDouble("Int16", value);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetSessionAttrInt16()
        {
            var value = HttpContext.Session.GetInt16("Int16");
            return new ContentResult { Content = value.HasValue ? value.ToString() : "null" };
        }

        public IActionResult SetSessionAttrInt64()
        {
            Int64 value = 123;
            HttpContext.Session.SetInt64("Int64", value);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetSessionAttrInt64()
        {
            var value = HttpContext.Session.GetInt64("Int64");
            return new ContentResult { Content = value.HasValue ? value.ToString() : "null" };
        }

        public IActionResult SetSessionAttrDecimal()
        {
            decimal value = 12.123456m;
            HttpContext.Session.SetDecimal("Decimal", value);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetSessionAttrDecimal()
        {
            var value = HttpContext.Session.GetDatetime("Decimal");
            return new ContentResult { Content = value.HasValue ? value.ToString() : "null" };
        }

        public IActionResult SetSessionAttrDatetime()
        {
            DateTime value = DateTime.Now;
            HttpContext.Session.SetDatetime("Datetime", value);
            return new ContentResult { Content = value.ToString() };
        }

        public IActionResult GetSessionAttrDatetime()
        {
            var value = HttpContext.Session.GetDatetime("Datetime");
            return new ContentResult { Content = value == null ? "null" : value.ToString() };
        }
    }
}
