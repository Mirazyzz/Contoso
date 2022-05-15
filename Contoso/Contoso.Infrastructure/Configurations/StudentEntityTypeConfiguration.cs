using Contoso.Domain.Entities;
using Contoso.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contoso.Infrastructure.Configurations
{
    internal class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(75);
            builder.Property(s => s.Gender)
                .HasDefaultValue(Gender.Undisclosed);
            builder.Property(s => s.BirthDate)
                .IsRequired(false);
        }
    }
}
