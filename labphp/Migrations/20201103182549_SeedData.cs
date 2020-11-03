using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmusementPark.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttractionList",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(nullable: false),
                    AttractionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionList", x => new { x.AttractionId, x.SubscriptionId });
                });

            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MaxFreeSeat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    AdultTickets = table.Column<int>(nullable: false),
                    ChildTickets = table.Column<int>(nullable: false),
                    SubscriptionId = table.Column<int>(nullable: false),
                    Checked = table.Column<bool>(nullable: false),
                    Accepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    PhoneNumber = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.PhoneNumber);
                });

            migrationBuilder.CreateTable(
                name: "ServiceList",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceList", x => new { x.ServiceId, x.SubscriptionId });
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ChildPrice = table.Column<decimal>(nullable: false),
                    AdultPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AttractionList",
                columns: new[] { "AttractionId", "SubscriptionId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 1, 2, 4 },
                    { 2, 2, 5 },
                    { 3, 2, 6 },
                    { 4, 2, 7 },
                    { 5, 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "Description", "MaxFreeSeat", "Name" },
                values: new object[,]
                {
                    { 5, "Американская горка маленькая", 8, "Американская горка S" },
                    { 4, "Американская горка большая", 12, "Американская горка L" },
                    { 1, "Мини-качели на башне", 10, "Воздушный самолет" },
                    { 2, "Связанный 30-ти метровый аттракцион", 24, "Лягушка" },
                    { 3, "Связанный аттракцион", 15, "Прыгучие" }
                });

            migrationBuilder.InsertData(
                table: "ServiceList",
                columns: new[] { "ServiceId", "SubscriptionId", "Id" },
                values: new object[,]
                {
                    { 4, 2, 7 },
                    { 6, 2, 8 },
                    { 5, 2, 8 },
                    { 3, 2, 6 },
                    { 2, 1, 2 },
                    { 1, 2, 4 },
                    { 3, 1, 3 },
                    { 1, 1, 1 },
                    { 2, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Безлимитное количество напитков", "Безлимитные напитки" },
                    { 2, "Безлимитное количество снеков", "Безлимитные снеки" },
                    { 3, "Безлимитное количество блюд", "Безлимитная еда" },
                    { 4, "Русская баня", "Баня" },
                    { 5, "Финская сауна", "Сауна" },
                    { 6, "Массаж", "Массаж" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AdultPrice", "ChildPrice", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 320m, 250m, "Все самое дешевое", "Лайт" },
                    { 2, 599m, 399m, "Все самое дорогое", "Люкс" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractionList");

            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ServiceList");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
