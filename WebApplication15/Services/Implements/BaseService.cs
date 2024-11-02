using WebApplication15.Db.Repository;

namespace WebApplication15.Services.Implements
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        private readonly IBaseRepository<T> _baseRepo;

        public BaseService(IBaseRepository<T> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public virtual IList<T> GetList()
        {
            return _baseRepo.GetList();
        }

        public virtual IList<T> GetPageList(int page, int pageSize, out int total)
        {
            return _baseRepo.GetPageList(page, pageSize, out total);
        }
    }
}
