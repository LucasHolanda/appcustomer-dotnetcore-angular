using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Infra.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired(true);
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(t => t.RegionId).IsRequired(true);

            builder.HasOne(t => t.Region);

            builder.HasData(new City { Id = 1, Name = "Porto Alegre", RegionId = 1 });
        }
    }
}
