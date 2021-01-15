using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Infra.Data.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired(true);
            builder.Property(t => t.Name).HasMaxLength(20).IsRequired(true);
            builder.Property(t => t.IsAdmin).IsRequired(true);

            builder.HasData(new UserRole { Id = 1, Name = "Administrator", IsAdmin = true });
            builder.HasData(new UserRole { Id = 2, Name = "Seller ", IsAdmin = false });
        }
    }
}
