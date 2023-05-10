using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicCentres.Data.EF.Migrations
{
    public partial class casePhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Cases",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Cases",
                newName: "Phone");
        }
    }
}
