
using System.Linq.Expressions;

using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;

using Microsoft.EntityFrameworkCore;

using WebApplication26.Db.Contexts;

namespace WebApplication26.Db.Service.Implement
{
    public class BaseService<T> : IBaseService<T> where T : class, new()
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepository<T> _repo;

        public BaseService(ApplicationDbContext context
            , IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.GetRepository<T>();
        }

        #region Query
        public virtual IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public virtual async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual T? GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public virtual async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public virtual IPagedList<T> GetPagedList(int pageIndex
            , int pageSize
            , int indexFrom = 0)
        {
            return _context.Set<T>().ToPagedList(pageIndex, pageSize, indexFrom);
        }
        #endregion
    }
}
