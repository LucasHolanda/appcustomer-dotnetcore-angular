using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCoreDDD.Domain.Entities;

namespace ProjectCoreDDD.Infra.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired(true);
            builder.Property(t => t.Name).IsRequired(true);
            builder.Property(t => t.Phone).IsRequired(true);
            builder.Property(t => t.GenderId).IsRequired(true);
            builder.Property(t => t.CityId).IsRequired(true);
            builder.Property(t => t.RegionId).IsRequired(true);
            builder.Property(t => t.LastPurchase).IsRequired(true);
            builder.Property(t => t.ClassificationId).IsRequired(true);
            builder.Property(t => t.UserId).IsRequired(true);

            builder.HasOne(t => t.Gender);
            builder.HasOne(t => t.City);
            builder.HasOne(t => t.Region);
            builder.HasOne(t => t.Classification);
            builder.HasOne(t => t.User);


            builder.HasData(new Customer { Id = 1, Name = "Maurício", Phone = "(11) 95429999", GenderId = 1, CityId = 1, RegionId = 1, LastPurchase = new System.DateTime(2016, 9, 10), ClassificationId = 1, UserId = 3 });
            builder.HasData(new Customer { Id = 2, Name = "Carla", Phone = "(53) 94569999", GenderId = 2, CityId = 1, RegionId = 1, LastPurchase = new System.DateTime(2015, 10, 10), ClassificationId = 1, UserId = 2 });
            builder.HasData(new Customer { Id = 3, Name = "Maria", Phone = "(64) 94518888", GenderId = 2, CityId = 1, RegionId = 1, LastPurchase = new System.DateTime(2013, 10, 12), ClassificationId = 3, UserId = 2 });
            builder.HasData(new Customer { Id = 4, Name = "Douglas", Phone = "(51) 12455555", GenderId = 1, CityId = 1, RegionId = 1, LastPurchase = new System.DateTime(2016, 5, 5), ClassificationId = 2, UserId = 2 });
            builder.HasData(new Customer { Id = 5, Name = "Marta", Phone = "(51) 45788888", GenderId = 2, CityId = 1, RegionId = 1, LastPurchase = new System.DateTime(2016, 8, 8), ClassificationId = 2, UserId = 3 });
        }
    }
}
