using Microsoft.AspNetCore.Mvc;

using SqlSugar;

namespace WebApplication16.Controllers
{
    public class SqlSugarClientController : Controller
    {
        private readonly ISqlSugarClient _sqlSugarClient;

        public SqlSugarClientController(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetConnectingString()
        {
            var text = _sqlSugarClient.CurrentConnectionConfig.ConnectionString;
            return new ContentResult { Content = text };
        }
    }
}
