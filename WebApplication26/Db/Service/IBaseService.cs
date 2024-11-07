using System.Linq.Expressions;

using Arch.EntityFrameworkCore.UnitOfWork.Collections;

namespace WebApplication26.Db.Service
{
    public interface IBaseService<T> where T : class, new()
    {
        #region Query
        IList<T> GetAll();

        Task<IList<T>> GetAllAsync();


        T? GetFirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        IPagedList<T> GetPagedList(int pageIndex
            , int pageSize
            , int indexFrom = 0);
        #endregion
    }
}
