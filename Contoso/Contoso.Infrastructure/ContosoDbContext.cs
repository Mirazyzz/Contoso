using Contoso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infrastructure
{
    public class ContosoDbContext : DbContext
    {
        public DbSet<BaseEntity> BaseEntity { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ContosoDbContext(DbContextOptions<ContosoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<Department>().ToTable("Department");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContosoDbContext).Assembly);
        }
    }
}
