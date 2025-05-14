using log4net;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using System.Configuration;
using WebApplication72.Config;

namespace WebApplication72.Db
{
    public class SqlSugarHelper
    {
        private static ILogger _logger;

        static SqlSugarHelper()
        {

        }

        public static void SetLogger(ILogger logger)
        {
            _logger = logger;
        }

        public static SqlSugarClient GetSqlSugarClient()
        {
            var connection = MyConfig.DbOptions.Default;
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig
            {
                DbType = (int)DbType.MySql,
                ConnectionString = connection,
                IsAutoCloseConnection = true,
                ConfigId = "Default"
            },
            db =>
            {
                db.Aop.OnLogExecuting = (sql, paras) =>
                {
                    string text = "";
                    if (paras != null && paras.Length > 0)
                    {
                        var ls = paras.Select(x => string.Format("{0}: {1}", x.ParameterName, x.Value)).ToList();
                        string text2 = string.Join(Environment.NewLine, ls);
                        text = string.Format("Prepare Execute Sql: {0}{1}{2}", sql, Environment.NewLine, text2);
                    }
                    else
                    {
                        text = string.Format("Prepare Execute Sql: {0}", sql);
                    }
                    _logger.LogInformation(text);
                };
            });

            return db;
        }
    }
}
