using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Infra.Data.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired(true);
            builder.Property(t => t.Name).HasMaxLength(20).IsRequired(true);

            builder.HasData(new Gender { Id = 1, Name = "Masculine" });
            builder.HasData(new Gender { Id = 2, Name = "Feminine" });

        }
    }
}
