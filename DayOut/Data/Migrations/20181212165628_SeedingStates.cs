using Microsoft.EntityFrameworkCore.Migrations;

namespace DayOut.Data.Migrations
{
    public partial class SeedingStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
