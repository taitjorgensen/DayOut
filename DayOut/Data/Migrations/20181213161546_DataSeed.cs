using Microsoft.EntityFrameworkCore.Migrations;

namespace DayOut.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('AK')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('AL')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('AR')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('AZ')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('CA')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('CO')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('CT')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('DE')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('FL')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('GA')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('HI')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('IA')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('ID')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('IL')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('IN')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('KS')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('LA')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('MA')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('MD')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('ME')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('MI')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('MN')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('MO')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('MS')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('MT')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('NC')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('ND')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('NE')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('NH')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('NJ')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('NM')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('NV')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('NY')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('OH')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('OK')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('OR')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('PA')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('RI')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('KY')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('SC')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('SD')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('TN')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('TX')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('UT')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('VA')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('VT')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('WA')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('WI')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('WV')");
            migrationBuilder.Sql("INSERT INTO States (Name) VALUES ('WY')");

            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Movie Theater', 230)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Park', 200)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Food', 130)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Cafe', 100)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Bowling', 130)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Ice Cream', 30)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Shopping', 200)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Mini Golf', 130)");
            migrationBuilder.Sql("INSERT INTO Categories (Name, TimeInHours) VALUES ('Museum', 230)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
