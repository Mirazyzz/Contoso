using Contoso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contoso.Infrastructure
{
    public class ContosoDbContext : DbContext
    {
        public virtual DbSet<BaseEntity> BaseEntity { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        public ContosoDbContext(DbContextOptions<ContosoDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<Department>().ToTable("Department");
            //modelBuilder.Entity<Student>().ToTable("Student");
            //modelBuilder.Entity<Subject>().ToTable("Subject");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContosoDbContext).Assembly);
        }
    }
}
