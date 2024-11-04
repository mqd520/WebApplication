using WebApplication16.Db.Repository;

namespace WebApplication16.Services.Implements
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected readonly IBaseRepository<T> _baseRepo;

        public BaseService(IBaseRepository<T> baseRepo)
        {
            _baseRepo = baseRepo;
        }
    }
}
