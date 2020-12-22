using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Infra.Data.Configuration
{
    public class UserSysConfiguration : IEntityTypeConfiguration<UserSys>
    {
        public void Configure(EntityTypeBuilder<UserSys> builder)
        {
            builder.ToTable("UserSys", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired(true);
            builder.Property(t => t.Login).IsRequired(true);
            builder.Property(t => t.Email).IsRequired(true);
            builder.Property(t => t.Password).IsRequired(true);
            builder.Property(t => t.UserRoleId).IsRequired(true);

            builder.HasOne(t => t.UserRole);

            builder.HasData(new UserSys { Id = 1, Login = "Administrator", Email = "admin@sellseverything.com", Password = "0192023a7bbd73250516f069df18b500" /* admin123 */, UserRoleId = 1 });
            builder.HasData(new UserSys { Id = 2, Login = "Seller1", Email = "seller1@sellseverything.com", Password = "1e4970ada8c054474cda889490de3421" /* seller1123 */, UserRoleId = 2 });
            builder.HasData(new UserSys { Id = 3, Login = "Seller2", Email = "seller2@sellseverything.com", Password = "c6e36755ccaf770bdfe44928358055c2" /* seller2123 */, UserRoleId = 2 });

        }
    }
}
