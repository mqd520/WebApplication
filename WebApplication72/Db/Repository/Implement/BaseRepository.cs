using SqlSugar;
using System.Linq.Expressions;

namespace WebApplication72.Db.Repository.Implement
{
    public class BaseRepository<TEntity> : SimpleClient<TEntity>, IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        public virtual ISqlSugarClient Db { get; set; }

        public BaseRepository(ISqlSugarClient context) : base(context)
        {
            Db = context;
        }

        #region Query
        #region Sync
        #region Other
        public virtual bool Exist(Expression<Func<TEntity, bool>> where)
        {
            return base.Count(where) > 0;
        }
        #endregion

        #region Query Single
        public virtual TEntity QueryById<TPrimaryKey>(TPrimaryKey id)
        {
            return base.GetById(id);
        }
        #endregion

        #region List
        public virtual IList<TEntity> QueryAll()
        {
            return base.GetList();
        }
        #endregion
        #endregion

        #region Async
        #region Other
        public virtual async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> where)
        {
            return await base.CountAsync(where) > 0;
        }
        #endregion

        #region Query Single
        public virtual async Task<TEntity> QueryByIdAsync<TPrimaryKey>(TPrimaryKey id)
        {
            return await base.GetByIdAsync(id);
        }
        #endregion
        #endregion

        #region List
        public virtual async Task<IList<TEntity>> QueryAllAsync()
        {
            return await base.GetListAsync();
        }
        #endregion
        #endregion

        #region Add
        #region Sync
        public virtual bool Add(TEntity entity)
        {
            return base.Insert(entity);
        }

        public virtual bool AddRange(IList<TEntity> entities)
        {
            return base.InsertRange(entities.ToArray());
        }

        public virtual int AddAndReturnId(TEntity entity)
        {
            return base.InsertReturnIdentity(entity);
        }

        public virtual TEntity AddAndReturnEntity(TEntity entity)
        {
            return base.InsertReturnEntity(entity);
        }

        public virtual bool AddByColumns(TEntity entity, params string[] columns)
        {
            return Context.Insertable(entity)
                    .InsertColumns(columns)
                    .ExecuteCommand() > 0;
        }

        public virtual bool AddByIgnoreColumns(TEntity entity, params string[] columns)
        {
            return Context.Insertable(entity)
                    .IgnoreColumns(columns)
                    .ExecuteCommand() > 0;
        }
        #endregion

        #region Async
        public virtual async Task<bool> AddAsync(TEntity entity)
        {
            return await base.InsertAsync(entity);
        }

        public virtual async Task<bool> AddRangeAsync(IList<TEntity> entities)
        {
            return await base.InsertRangeAsync(entities.ToArray());
        }

        public virtual async Task<int> AddAndReturnIdAsync(TEntity entity)
        {
            return await base.InsertReturnIdentityAsync(entity);
        }

        public virtual async Task<TEntity> AddAndReturnEntityAsync(TEntity entity)
        {
            return await base.InsertReturnEntityAsync(entity);
        }

        public virtual async Task<bool> AddByColumnsAsync(TEntity entity, params string[] columns)
        {
            return await Context.Insertable(entity)
                    .InsertColumns(columns)
                    .ExecuteCommandAsync() > 0;
        }

        public virtual async Task<bool> AddByIgnoreColumnsAsync(TEntity entity, params string[] columns)
        {
            return await Context.Insertable(entity)
                    .IgnoreColumns(columns)
                    .ExecuteCommandAsync() > 0;
        }
        #endregion
        #endregion

        #region Delete
        #region Sync
        public virtual bool DeleteById<TPrimaryKey>(TPrimaryKey id)
        {
            return base.DeleteById(id);
        }

        public virtual int DeleteByIds<TPrimaryKey>(IEnumerable<TPrimaryKey> ids)
        {
            return Context.Deleteable<TEntity>()
                    .In(ids)
                    .ExecuteCommand();
        }

        public virtual int DeleteByWhere(Expression<Func<TEntity, bool>> where)
        {
            return Context.Deleteable<TEntity>().Where(where).ExecuteCommand();
        }
        #endregion

        #region  Async
        public virtual async Task<bool> DeleteByIdAsync<TPrimaryKey>(TPrimaryKey id)
        {
            return await Context.Deleteable<TEntity>()
                    .In<TPrimaryKey>(id)
                    .ExecuteCommandAsync() > 0;
        }

        public virtual async Task<bool> DeleteByIdsAsync<TPrimaryKey>(IEnumerable<TPrimaryKey> ids)
        {
            return await Context.Deleteable<TEntity>()
                    .In<TPrimaryKey>(ids.ToArray())
                    .ExecuteCommandAsync() > 0;
        }

        public virtual async Task<int> DeleteByWhereAsync(Expression<Func<TEntity, bool>> where)
        {
            return await Context.Deleteable<TEntity>()
                            .Where(where)
                            .ExecuteCommandAsync();
        }
        #endregion
        #endregion

        #region Update
        #region Sync
        public virtual int Update(TEntity entity, Expression<Func<TEntity, object>> where)
        {
            return Context.Updateable(entity).WhereColumns(where).ExecuteCommand();
        }

        public virtual int Update(TEntity entity, params string[] columns)
        {
            return Context.Updateable(entity).UpdateColumns(columns).ExecuteCommand();
        }
        #endregion

        #region Async
        #endregion
        #endregion
    }
}
