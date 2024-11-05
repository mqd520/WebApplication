using Microsoft.AspNetCore.Mvc;

using SqlSugar;

using WebApplication16.Db.Entity;

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

        public IActionResult GetAllCustomers()
        {
            var ls = _sqlSugarClient.Queryable<CustomerEntity>().ToList();
            return new JsonResult(ls);
        }
    }
}
