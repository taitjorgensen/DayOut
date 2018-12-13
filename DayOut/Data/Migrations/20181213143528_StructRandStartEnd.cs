using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DayOut.Data.Migrations
{
    public partial class StructRandStartEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RandEndTime",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RandStartTime",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StructEndTime",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StructStartTime",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RandEndTime",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RandStartTime",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StructEndTime",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StructStartTime",
                table: "Customers");
        }
    }
}
