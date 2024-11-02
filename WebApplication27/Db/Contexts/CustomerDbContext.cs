using Microsoft.EntityFrameworkCore;

using WebApplication27.Db.Entity;

namespace WebApplication27.Db.Contexts
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
