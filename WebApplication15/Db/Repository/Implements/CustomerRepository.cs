using SqlSugar;

using WebApplication15.Db.Entity;

namespace WebApplication15.Db.Repository.Implements
{
    public class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(ISqlSugarClient db) : base(db)
        {

        }

        public virtual IList<CustomerEntity> QueryAllCustomers()
        {
            return GetList();
        }
    }
}
