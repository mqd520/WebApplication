using SqlSugar;

namespace WebApplication16.Db
{
    /// <summary>
    /// SqlSugar Helper
    /// </summary>
    public static class SqlSugarHelper
    {
        public static IServiceProvider ServiceProvider { get; set; } = default!;

        public static SqlSugarScope CreateSqlSugarScope(string connectingString)
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
            var service = ServiceProvider.GetRequiredService<SqlSugarLogger>();
            service.Log(sql);
        }

        private static void OnLogExecuted(string sql, SugarParameter[] paras)
        {

        }
    }

    public class SqlSugarLogger
    {
        private readonly ILogger<SqlSugarLogger> _logger;

        public SqlSugarLogger(ILogger<SqlSugarLogger> logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
