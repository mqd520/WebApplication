using Microsoft.AspNetCore.Mvc;

using SqlSugar;

namespace WebApplication15.Controllers
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
    }
}
