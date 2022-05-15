using Contoso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contoso.Infrastructure.Configurations
{
    internal class EnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");

            builder.HasKey(e => e.EnrollmentId);

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);
            builder.HasOne(e => e.Subject)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.SubjectId);

            builder.Property(e => e.EnrollmentId)
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Grade)
                .IsRequired(false);
        }
    }
}
