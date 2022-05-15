using Contoso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contoso.Infrastructure.Configurations
{
    internal class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.CityId);

            builder.Property(c => c.CityName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(c => c.Departments)
                .WithOne(d => d.City)
                .HasForeignKey(d => d.CityId);
        }
    }
}
