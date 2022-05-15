using Contoso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infrastructure
{
    public class ContosoDbContext : DbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        public ContosoDbContext(DbContextOptions<ContosoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContosoDbContext).Assembly);
        }
    }
}
