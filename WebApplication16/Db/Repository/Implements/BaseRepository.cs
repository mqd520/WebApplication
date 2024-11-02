using SqlSugar;

using WebApplication16.Interceptors;

namespace WebApplication16.Db.Repository.Implements
{
    public class BaseRepository<T> : SimpleClient<T>, IBaseRepository<T>
        where T : class, new()
    {
        public BaseRepository(ISqlSugarClient db)
        {
            base.Context = db;
        }

        [UseDbTran]
        public virtual void Test()
        {

        }
    }
}
