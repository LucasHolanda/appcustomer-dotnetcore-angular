using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Infra.Data.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired(true);
            builder.Property(t => t.Name).IsRequired(true);

            builder.HasData(new Region { Id = 1, Name = "Rio Grande do Sul" });
            builder.HasData(new Region { Id = 2, Name = "São Paulo" });
            builder.HasData(new Region { Id = 3, Name = "Curitiba" });
        }
    }
}
