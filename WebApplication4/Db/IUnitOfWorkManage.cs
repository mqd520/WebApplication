namespace WebApplication4.Db
{
    public interface IUnitOfWorkManage
    {
        void BeginTran();

        void CommitTran();

        void RollbackTran();
    }
}
