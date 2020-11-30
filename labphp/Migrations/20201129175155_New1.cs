using Microsoft.EntityFrameworkCore.Migrations;

namespace AmusementPark.Migrations
{
    public partial class New1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubscriptionServices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubscriptionAttractions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubscriptionServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubscriptionAttractions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
