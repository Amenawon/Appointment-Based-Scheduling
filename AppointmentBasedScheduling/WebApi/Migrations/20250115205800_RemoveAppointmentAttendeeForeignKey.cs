using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class RemoveAppointmentAttendeeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ToAttendees",
                table: "Appointments");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ToAttendees",
                table: "Appointments",
                column: "Attendees",
                principalTable: "Attendees",
                principalColumn: "Id");
        }
    }
}
