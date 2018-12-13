using Microsoft.EntityFrameworkCore.Migrations;

namespace DayOut.Data.Migrations
{
    public partial class TimeInHoursDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TimeInHours",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Movie Theater', 2.5)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Park', 2)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Food', 1.5)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Cafe', 1)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Bowling', 1.5)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Ice Cream', 0.5)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Shopping', 2)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Mini Golf', 1.5)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimeInHours",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
