using SqlSugar;
using System.Linq.Expressions;
using System.Reflection;

namespace WebApplication72.Db
{
    public static class EntityTool
    {
        public static string GetFieldName<TEntity, TField>(Expression<Func<TEntity, TField>> where)
            where TEntity : class
        {
            var result = "";

            var paramName = "";
            if (where != null)
            {
                var body = where.Body as MemberExpression;
                if (body != null && body.Member != null)
                {
                    paramName = body.Member.Name;
                }
            }

            if (!string.IsNullOrEmpty(paramName))
            {
                var type = typeof(SugarTable);
                var type2 = typeof(TEntity);
                if (type2.GetCustomAttribute(type) != null)
                {
                    var piArr = type2.GetProperties();
                    foreach (var pi in piArr)
                    {
                        if (pi.Name == paramName)
                        {
                            var type3 = pi.GetCustomAttribute(typeof(SugarColumn));
                            if (type3 != null)
                            {
                                var attr = (SugarColumn)type3;
                                if (!string.IsNullOrEmpty(attr.ColumnName))
                                {
                                    result = attr.ColumnName;
                                }
                                else
                                {
                                    result = paramName;
                                }
                            }
                            else
                            {
                                result = paramName;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    var text = $"{type2.Name} Not Found SugarTable Attribute";
                    throw new Exception(text);
                }
            }

            return result;
        }

        public static string GetTableName<TEntity>() where TEntity : class
        {
            var result = "";

            var type = typeof(TEntity);
            var type2 = typeof(SugarTable);
            var attr = type.GetCustomAttribute(type2) as SugarTable;
            if (attr != null)
            {
                result = attr.TableName;
            }
            else
            {
                var text = $"{type.Name} Not Found SugarTable Attribute";
                throw new Exception(text);
            }

            return result;
        }
    }
}
