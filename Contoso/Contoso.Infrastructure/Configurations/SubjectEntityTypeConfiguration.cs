using Contoso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contoso.Infrastructure.Configurations
{
    internal class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");

            builder.HasKey(s => s.SubjectId);

            builder.HasMany(s => s.Enrollments)
                .WithOne(e => e.Subject)
                .HasForeignKey(e => e.SubjectId);

            builder.Property(s => s.SubjectName)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(s => s.Fee)
                .IsRequired()
                .HasDefaultValue(100);
            builder.Property(s => s.TotalHours)
                .IsRequired(false)
                .HasDefaultValue(40);
        }
    }
}
