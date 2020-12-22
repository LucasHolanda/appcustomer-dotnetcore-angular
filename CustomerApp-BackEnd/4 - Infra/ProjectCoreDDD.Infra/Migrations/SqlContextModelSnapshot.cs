﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectCoreDDD.Infra.Data;

namespace ProjectCoreDDD.Infra.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("City","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Porto Alegre",
                            RegionId = 1
                        });
                });

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.Classification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classification","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "VIP"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Regular"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sporadic"
                        });
                });

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassificationId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastPurchase")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("GenderId");

                    b.HasIndex("RegionId");

                    b.HasIndex("UserId");

                    b.ToTable("Customer","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            ClassificationId = 1,
                            GenderId = 1,
                            LastPurchase = new DateTime(2016, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Maurício",
                            Phone = "(11) 95429999",
                            RegionId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            ClassificationId = 1,
                            GenderId = 2,
                            LastPurchase = new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Carla",
                            Phone = "(53) 94569999",
                            RegionId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            ClassificationId = 3,
                            GenderId = 2,
                            LastPurchase = new DateTime(2013, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Maria",
                            Phone = "(64) 94518888",
                            RegionId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            CityId = 1,
                            ClassificationId = 2,
                            GenderId = 1,
                            LastPurchase = new DateTime(2016, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Douglas",
                            Phone = "(51) 12455555",
                            RegionId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 5,
                            CityId = 1,
                            ClassificationId = 2,
                            GenderId = 2,
                            LastPurchase = new DateTime(2016, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Marta",
                            Phone = "(51) 45788888",
                            RegionId = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Masculine"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Feminine"
                        });
                });

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Region","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rio Grande do Sul"
                        },
                        new
                        {
                            Id = 2,
                            Name = "São Paulo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Curitiba"
                        });
                });

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRole","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAdmin = true,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            IsAdmin = false,
                            Name = "Seller "
                        });
                });

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.UserSys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("UserSys","dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@sellseverything.com",
                            Login = "Administrator",
                            Password = "0192023a7bbd73250516f069df18b500",
                            UserRoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "seller1@sellseverything.com",
                            Login = "Seller1",
                            Password = "1e4970ada8c054474cda889490de3421",
                            UserRoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "seller2@sellseverything.com",
                            Login = "Seller2",
                            Password = "c6e36755ccaf770bdfe44928358055c2",
                            UserRoleId = 2
                        });
                });

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.City", b =>
                {
                    b.HasOne("ProjectCoreDDD.Domain.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.Customer", b =>
                {
                    b.HasOne("ProjectCoreDDD.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectCoreDDD.Domain.Entities.Classification", "Classification")
                        .WithMany()
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ProjectCoreDDD.Domain.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectCoreDDD.Domain.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectCoreDDD.Domain.Entities.UserSys", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectCoreDDD.Domain.Entities.UserSys", b =>
                {
                    b.HasOne("ProjectCoreDDD.Domain.Entities.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
