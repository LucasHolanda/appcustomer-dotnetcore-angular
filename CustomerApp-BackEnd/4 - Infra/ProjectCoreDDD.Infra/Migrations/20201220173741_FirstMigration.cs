using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCoreDDD.Infra.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Classification",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Region_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "dbo",
                        principalTable: "Region",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSys",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSys_UserRole_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "dbo",
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    LastPurchase = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ClassificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "dbo",
                        principalTable: "City",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_Classification_ClassificationId",
                        column: x => x.ClassificationId,
                        principalSchema: "dbo",
                        principalTable: "Classification",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_Gender_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "dbo",
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_Region_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "dbo",
                        principalTable: "Region",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Customer_UserSys_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "UserSys",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction,
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Classification",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "VIP" },
                    { 2, "Regular" },
                    { 3, "Sporadic" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Masculine" },
                    { 2, "Feminine" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Region",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rio Grande do Sul" },
                    { 2, "São Paulo" },
                    { 3, "Curitiba" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRole",
                columns: new[] { "Id", "IsAdmin", "Name" },
                values: new object[,]
                {
                    { 1, true, "Administrator" },
                    { 2, false, "Seller " }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "City",
                columns: new[] { "Id", "Name", "RegionId" },
                values: new object[] { 1, "Porto Alegre", 1 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserSys",
                columns: new[] { "Id", "Email", "Login", "Password", "UserRoleId" },
                values: new object[,]
                {
                    { 1, "admin@sellseverything.com", "Administrator", "0192023a7bbd73250516f069df18b500", 1 },
                    { 2, "seller1@sellseverything.com", "Seller1", "1e4970ada8c054474cda889490de3421", 2 },
                    { 3, "seller2@sellseverything.com", "Seller2", "c6e36755ccaf770bdfe44928358055c2", 2 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Customer",
                columns: new[] { "Id", "CityId", "ClassificationId", "GenderId", "LastPurchase", "Name", "Phone", "RegionId", "UserId" },
                values: new object[,]
                {
                    { 2, 1, 1, 2, new DateTime(2015, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carla", "(53) 94569999", 1, 2 },
                    { 3, 1, 3, 2, new DateTime(2013, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "(64) 94518888", 1, 2 },
                    { 4, 1, 2, 1, new DateTime(2016, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Douglas", "(51) 12455555", 1, 2 },
                    { 1, 1, 1, 1, new DateTime(2016, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maurício", "(11) 95429999", 1, 3 },
                    { 5, 1, 2, 2, new DateTime(2016, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marta", "(51) 45788888", 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_RegionId",
                schema: "dbo",
                table: "City",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CityId",
                schema: "dbo",
                table: "Customer",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ClassificationId",
                schema: "dbo",
                table: "Customer",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_GenderId",
                schema: "dbo",
                table: "Customer",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_RegionId",
                schema: "dbo",
                table: "Customer",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                schema: "dbo",
                table: "Customer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSys_UserRoleId",
                schema: "dbo",
                table: "UserSys",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "City",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Classification",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Gender",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserSys",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbo");
        }
    }
}
