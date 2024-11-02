
using WebApplication26.Db.Contexts;
using WebApplication26.Db.Entity;

namespace WebApplication26.Db.DAO.Implement
{
    public class CustomerDAO : ICustomerDAO
    {
        public readonly ApplicationDbContext Context;

        public CustomerDAO(ApplicationDbContext context)
        {
            Context = context;
        }

        public IList<CustomerEntity> GetAll()
        {
            return Context.Customers.ToList();
        }
    }
}
