using Microsoft.EntityFrameworkCore.Migrations;

namespace DayOut.Data.Migrations
{
    public partial class CustomerRouteTypeBools : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RandomizedMode",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StructuredMode",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SurpriseMode",
                table: "Customers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RandomizedMode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StructuredMode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SurpriseMode",
                table: "Customers");
        }
    }
}
