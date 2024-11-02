using SqlSugar;

namespace WebApplication15.Db.Repository.Implements
{
    public class BaseRepository<T> : SimpleClient<T>, IBaseRepository<T>
        where T : class, new()
    {
        public BaseRepository(ISqlSugarClient db)
        {
            base.Context = db;
        }

        public virtual IList<T> ToPageList(int PageNow, int PageSize)
        {
            return Context.Queryable<T>().Skip(PageSize * (PageNow - 1)).Take(PageSize).ToList();
        }

        public virtual IList<T> GetPageList(int page, int pageSize, out int total)
        {
            total = 0;
            total = Context.Queryable<T>().Count();
            if (total > 0)
            {
                return Context.Queryable<T>().Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            }
            else
            {
                return new List<T>();
            }
        }
    }
}
