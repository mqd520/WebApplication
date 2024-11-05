using WebApplication16.Db.Repository;

namespace WebApplication16.Db.Services.Implements
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected readonly IBaseRepository<T> _baseRepo;

        public BaseService(IBaseRepository<T> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public virtual IList<T> GetList()
        {
            return _baseRepo.GetList();
        }
    }
}
