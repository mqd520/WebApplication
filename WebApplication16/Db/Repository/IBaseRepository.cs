using SqlSugar;

namespace WebApplication16.Db.Repository
{
    public interface IBaseRepository<T> : ISimpleClient<T> where T : class, new()
    {

    }
}
