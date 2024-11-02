namespace WebApplication16.Db.Tran
{
    public interface IUnitOfWorkManage
    {
        void BeginTran();

        void CommitTran();

        void RollbackTran();
    }
}
