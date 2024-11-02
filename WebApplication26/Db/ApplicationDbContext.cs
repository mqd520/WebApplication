using Microsoft.EntityFrameworkCore;

using WebApplication26.Db.Entity;

namespace WebApplication26.Db.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerEntity>()
                .Property(x => x.Fax)
                .IsRequired(false);
        }
    }
}
