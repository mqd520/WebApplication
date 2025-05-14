using SqlSugar;
using System.Linq.Expressions;

namespace WebApplication72.Db.Repository
{
    public interface IBaseRepository<TEntity> : ISimpleClient<TEntity>
        where TEntity : class, new()
    {
        ISqlSugarClient Db { get; set; }

        #region Query
        #region Sync
        #region Other
        bool Exist(Expression<Func<TEntity, bool>> where);
        #endregion

        #region Query Single
        TEntity QueryById<TPrimaryKey>(TPrimaryKey id);
        #endregion

        #region List
        IList<TEntity> QueryAll();
        #endregion
        #endregion

        #region Async
        #region Other
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> where);
        #endregion

        #region Query Single
        Task<TEntity> QueryByIdAsync<TPrimaryKey>(TPrimaryKey id);
        #endregion

        #region List
        Task<IList<TEntity>> QueryAllAsync();
        #endregion
        #endregion
        #endregion

        #region Add
        #region Sync
        bool Add(TEntity entity);

        bool AddRange(IList<TEntity> entities);

        int AddAndReturnId(TEntity entity);

        TEntity AddAndReturnEntity(TEntity entity);

        bool AddByColumns(TEntity entity, params string[] columns);

        bool AddByIgnoreColumns(TEntity entity, params string[] columns);
        #endregion

        #region Async
        Task<bool> AddAsync(TEntity entity);

        Task<bool> AddRangeAsync(IList<TEntity> entities);

        Task<int> AddAndReturnIdAsync(TEntity entity);

        Task<TEntity> AddAndReturnEntityAsync(TEntity entity);

        Task<bool> AddByColumnsAsync(TEntity entity, params string[] columns);

        Task<bool> AddByIgnoreColumnsAsync(TEntity entity, params string[] columns);
        #endregion
        #endregion

        #region Delete
        #region Sync
        bool DeleteById<TPrimaryKey>(TPrimaryKey id);

        int DeleteByIds<TPrimaryKey>(IEnumerable<TPrimaryKey> ids);

        int DeleteByWhere(Expression<Func<TEntity, bool>> where);
        #endregion

        #region  Async
        Task<bool> DeleteByIdAsync<TPrimaryKey>(TPrimaryKey id);

        Task<bool> DeleteByIdsAsync<TPrimaryKey>(IEnumerable<TPrimaryKey> ids);

        Task<int> DeleteByWhereAsync(Expression<Func<TEntity, bool>> where);
        #endregion
        #endregion

        #region Update
        #region Sync
        int Update(TEntity entity, Expression<Func<TEntity, object>> where);

        int Update(TEntity entity, params string[] columns);
        #endregion

        #region Async
        #endregion
        #endregion
    }
}
