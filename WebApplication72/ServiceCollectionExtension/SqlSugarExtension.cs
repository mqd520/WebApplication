using log4net;
using SqlSugar;
using System.Xml.Linq;
using WebApplication72.Db;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication72.ServiceCollectionExtension
{
    public static class SqlSugarExtension
    {
        public static void AddSqlSugar(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var factory = provider.GetService<ILoggerFactory>();
            if (factory != null)
            {
                var logger = factory.CreateLogger(typeof(SqlSugarHelper).Name);
                SqlSugarHelper.SetLogger(logger);
            }

            services.AddScoped<ISqlSugarClient, SqlSugarClient>(provider =>
            {
                return SqlSugarHelper.GetSqlSugarClient();
            });
        }
    }
}
