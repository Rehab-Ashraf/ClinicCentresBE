using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicCentres.Data.EF.Migrations
{
    public partial class appointmentcaseidnotrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Cases_CaseId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Cases_CaseId",
                table: "Appointments",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Cases_CaseId",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Cases_CaseId",
                table: "Appointments",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
