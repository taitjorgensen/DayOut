using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DayOut.Data.Migrations
{
    public partial class Time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StandardTime = table.Column<string>(nullable: true),
                    MilitaryTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                });

            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('12:00 AM', 2400)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('12:30 AM', 0030)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('1:00 AM', 0100)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('1:30 AM', 0130)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('2:00 AM', 0200)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('2:30 AM', 0230)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('3:00 AM', 0300)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('3:30 AM', 0330)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('4:00 AM', 0400)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('4:30 AM', 0430)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('5:00 AM', 0500)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('5:30 AM', 0530)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('6:00 AM', 0600)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('6:30 AM', 0630)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('7:00 AM', 0700)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('7:30 AM', 0730)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('8:00 AM', 0800)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('8:30 AM', 0830)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('9:00 AM', 0900)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('9:30 AM', 0930)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('10:00 AM', 1000)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('10:30 AM', 1030)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('11:00 AM', 1100)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('11:30 AM', 1130)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('12:00 PM', 1200)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('12:30 PM', 1230)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('1:00 PM', 1300)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('1:30 PM', 1330)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('2:00 PM', 1400)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('2:30 PM', 1430)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('3:00 PM', 1500)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('3:30 PM', 1530)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('4:00 PM', 1600)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('4:30 PM', 1630)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('5:00 PM', 1700)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('5:30 PM', 1730)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('6:00 PM', 1800)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('6:30 PM', 1830)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('7:00 PM', 1900)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('7:30 PM', 1930)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('8:00 PM', 2000)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('8:30 PM', 2030)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('9:00 PM', 2100)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('9:30 PM', 2130)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('10:00 PM', 2200)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('10:30 PM', 2230)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('11:00 PM', 2300)");
            migrationBuilder.Sql("INSERT INTO Times (StandardTime, MilitaryTime) VALUES ('11:30 PM', 2330)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}
