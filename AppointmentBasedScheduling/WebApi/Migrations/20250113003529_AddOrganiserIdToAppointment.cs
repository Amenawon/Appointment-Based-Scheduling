using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddOrganiserIdToAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ToUsers",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "OrganiserId",
                table: "Appointments",
                type: "nvarchar(128)",
                nullable: false);

            migrationBuilder.DropColumn(
                name: "Organiser",
                table: "Appointments");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Users_OrganiserId",
                table: "Appointments",
                column: "OrganiserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Users_OrganiserId",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Organiser",
                table: "Appointments",
                type: "nvarchar(128)",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ToUsers",
                table: "Appointments",
                column: "Organiser",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.DropColumn(
                name: "OrganiserId",
                table: "Appointments");
        }
    }
}
