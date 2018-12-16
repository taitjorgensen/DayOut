using Microsoft.EntityFrameworkCore.Migrations;

namespace DayOut.Data.Migrations
{
    public partial class CustomerFKPlacesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Places",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Places_CustomerId",
                table: "Places",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Customers_CustomerId",
                table: "Places",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Customers_CustomerId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_CustomerId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Places");
        }
    }
}
