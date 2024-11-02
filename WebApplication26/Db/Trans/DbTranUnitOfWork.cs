using Microsoft.EntityFrameworkCore.Storage;

using WebApplication26.Db.Contexts;

namespace WebApplication26.Db.Trans
{
    public class DbTranUnitOfWork : IDbTranUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private IDbContextTransaction? _transaction;

        public DbTranUnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void BeginTransaction()
        {
            _transaction = _applicationDbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }

        public void RoolbackTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }
    }
}
