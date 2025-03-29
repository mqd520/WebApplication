using Microsoft.EntityFrameworkCore;

using WebApplication29.Db.Entity;

namespace WebApplication29.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
