using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicCentres.Data.EF.Migrations
{
    public partial class renameAppointmentDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Appointments",
                newName: "DayTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayTime",
                table: "Appointments",
                newName: "Day");
        }
    }
}
