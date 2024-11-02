using SqlSugar;

namespace WebApplication15.Db
{
    /// <summary>
    /// SqlSugar Helper
    /// </summary>
    public static class SqlSugarHelper
    {
        public static IServiceProvider? ServiceProvider { get; set; }

        public static SqlSugarScope GetSqlSugarScope(string connectingString)
        {
            var sqlSugarScope = new SqlSugarScope(new ConnectionConfig()
            {
                DbType = DbType.MySql,
                ConnectionString = connectingString,
                IsAutoCloseConnection = true
            }, db =>
            {
                db.Aop.OnLogExecuting = OnLogExecuting;
                db.Aop.OnLogExecuted = OnLogExecuted;
            });

            return sqlSugarScope;
        }

        private static void OnLogExecuting(string sql, SugarParameter[] paras)
        {
            var httpContextAccessor = ServiceProvider?.GetService<IHttpContextAccessor>();
            var logger = httpContextAccessor?.HttpContext?.RequestServices.GetService<SqlSugarHelperLogger>();
            logger?.Log(sql);
        }

        private static void OnLogExecuted(string sql, SugarParameter[] paras)
        {

        }
    }

    public class SqlSugarHelperLogger
    {
        private readonly ILogger<SqlSugarHelperLogger> _logger;

        public SqlSugarHelperLogger(ILogger<SqlSugarHelperLogger> logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
