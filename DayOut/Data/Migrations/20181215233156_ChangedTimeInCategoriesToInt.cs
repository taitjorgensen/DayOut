using Microsoft.EntityFrameworkCore.Migrations;

namespace DayOut.Data.Migrations
{
    public partial class ChangedTimeInCategoriesToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeInHours",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "TimeToDo",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeToDo",
                table: "Categories");

            migrationBuilder.AddColumn<double>(
                name: "TimeInHours",
                table: "Categories",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
