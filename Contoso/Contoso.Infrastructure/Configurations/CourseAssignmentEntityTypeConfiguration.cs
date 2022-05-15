using Contoso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contoso.Infrastructure.Configurations
{
    internal class CourseAssignmentEntityTypeConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            builder.ToTable("CourseAssignment");

            builder.HasKey(ca => ca.CourseAssignmentId);

            builder.HasOne(ca => ca.Instructor)
                .WithMany(i => i.CourseAssignments)
                .HasForeignKey(ca => ca.InstructorId);
            builder.HasOne(ca => ca.Subject)
                .WithMany(s => s.CourseAssignments)
                .HasForeignKey(ca => ca.SubjectId);

            builder.Property(ca => ca.SalaryPerHour)
                .IsRequired(false)
                .HasDefaultValue(25m);
        }
    }
}
