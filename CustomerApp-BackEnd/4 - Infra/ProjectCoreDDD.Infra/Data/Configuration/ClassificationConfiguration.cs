using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Infra.Data.Configuration
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            builder.ToTable("Classification", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired(true);
            builder.Property(t => t.Name).HasMaxLength(20).IsRequired(true);

            builder.HasData(new Classification { Id = 1, Name = "VIP" });
            builder.HasData(new Classification { Id = 2, Name = "Regular" });
            builder.HasData(new Classification { Id = 3, Name = "Sporadic" });

        }
    }
}
