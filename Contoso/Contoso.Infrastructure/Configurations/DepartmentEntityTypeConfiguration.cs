using Contoso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contoso.Infrastructure.Configurations
{
    internal class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(d => d.DepartmentId);

            builder.HasOne(d => d.City)
                .WithMany(c => c.Departments)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(d => d.DepartmentId)
                .ValueGeneratedOnAdd();
            builder.Property(d => d.DepartmentName)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
