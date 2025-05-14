using SqlSugar;
using WebApplication72.Db.Repository;

namespace WebApplication72.Services.Implement
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class, new()
    {
        public IBaseRepository<TEntity> Repos { get; set; }

        public BaseService(IBaseRepository<TEntity> repos)
        {
            Repos = repos;
        }
    }
}
