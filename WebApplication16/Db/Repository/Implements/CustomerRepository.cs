using SqlSugar;

using WebApplication16.Db.Entity;

namespace WebApplication16.Db.Repository.Implements
{
    public class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(ISqlSugarClient db) : base(db)
        {

        }
    }
}
