using SqlSugar;

namespace WebApplication16.Db.Tran
{
    public class UnitOfWorkManage : IUnitOfWorkManage
    {
        private readonly ISqlSugarClient _sqlSugarClient;

        public UnitOfWorkManage(ISqlSugarClient sqlSugarClient)
        {
            _sqlSugarClient = sqlSugarClient;
        }

        public void BeginTran()
        {
            _sqlSugarClient.Ado.BeginTran();
        }

        public void CommitTran()
        {
            _sqlSugarClient.Ado.CommitTran();
        }

        public void RollbackTran()
        {
            _sqlSugarClient.Ado.RollbackTran();
        }
    }
}
