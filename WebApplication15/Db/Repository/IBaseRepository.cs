using SqlSugar;

namespace WebApplication15.Db.Repository
{
    public interface IBaseRepository<T> : ISimpleClient<T> where T : class, new()
    {
        IList<T> ToPageList(int PageNow, int PageSize);

        IList<T> GetPageList(int page, int pageSize, out int total);
    }
}
