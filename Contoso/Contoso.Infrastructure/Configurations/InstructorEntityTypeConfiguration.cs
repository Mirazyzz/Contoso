using Contoso.Domain.Entities;
using Contoso.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contoso.Infrastructure.Configurations
{
    internal class InstructorEntityTypeConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructor");

            builder.HasKey(i => i.InstructorId);

            builder.HasMany(i => i.CourseAssignments)
                .WithOne(ca => ca.Instructor)
                .HasForeignKey(ca => ca.InstructorId);

            builder.HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentId);

            builder.Property(i => i.FullName)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(i => i.HireDate)
                .IsRequired(false)
                .HasDefaultValue(DateTime.MinValue);
            builder.Property(i => i.Gender)
                .IsRequired(false)
                .HasDefaultValue(Gender.Undisclosed);
        }
    }
}
