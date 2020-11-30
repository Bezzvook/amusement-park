using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmusementPark.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
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
                    ChildPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdultPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    AdultTickets = table.Column<int>(nullable: false),
                    ChildTickets = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    SubscriptionId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionAttractions",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(nullable: false),
                    AttractionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionAttractions", x => new { x.AttractionId, x.SubscriptionId });
                    table.ForeignKey(
                        name: "FK_SubscriptionAttractions_Attractions_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionAttractions_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionServices",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionServices", x => new { x.ServiceId, x.SubscriptionId });
                    table.ForeignKey(
                        name: "FK_SubscriptionServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionServices_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "Description", "MaxFreeSeat", "Name" },
                values: new object[,]
                {
                    { 1, "Мини-качели на башне", 10, "Воздушный самолет" },
                    { 2, "Связанный 30-ти метровый аттракцион", 24, "Лягушка" },
                    { 3, "Связанный аттракцион", 15, "Прыгучие" },
                    { 4, "Американская горка большая", 12, "Американская горка L" },
                    { 5, "Американская горка маленькая", 8, "Американская горка S" }
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

            migrationBuilder.InsertData(
                table: "SubscriptionAttractions",
                columns: new[] { "AttractionId", "SubscriptionId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 5, 2, 0 },
                    { 4, 2, 0 },
                    { 2, 2, 0 },
                    { 1, 2, 0 },
                    { 3, 2, 0 },
                    { 3, 1, 0 },
                    { 2, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionServices",
                columns: new[] { "ServiceId", "SubscriptionId", "Id" },
                values: new object[,]
                {
                    { 2, 1, 0 },
                    { 1, 1, 0 },
                    { 5, 2, 0 },
                    { 1, 2, 0 },
                    { 2, 2, 0 },
                    { 3, 2, 0 },
                    { 4, 2, 0 },
                    { 3, 1, 0 },
                    { 6, 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClientId",
                table: "Booking",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SubscriptionId",
                table: "Booking",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Link",
                table: "Clients",
                column: "Link",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionAttractions_SubscriptionId",
                table: "SubscriptionAttractions",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionServices_SubscriptionId",
                table: "SubscriptionServices",
                column: "SubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "SubscriptionAttractions");

            migrationBuilder.DropTable(
                name: "SubscriptionServices");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
