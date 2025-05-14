using SqlSugar;
using WebApplication72.Db.Entity;

namespace WebApplication72.Db.Repository.Implement
{
    public class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(ISqlSugarClient context) : base(context)
        {

        }
    }
}
