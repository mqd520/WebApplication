namespace WebApplication26.Db.Trans
{
    public interface IDbTranUnitOfWork
    {
        void BeginTransaction();

        void CommitTransaction();

        void RoolbackTransaction();
    }
}
