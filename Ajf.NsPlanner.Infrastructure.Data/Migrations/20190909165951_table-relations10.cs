using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class tablerelations10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_EventRequest_EventRequestId",
                table: "Assignments");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_EventRequest_EventRequestId",
                table: "Assignments",
                column: "EventRequestId",
                principalTable: "EventRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_EventRequest_EventRequestId",
                table: "Assignments");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_EventRequest_EventRequestId",
                table: "Assignments",
                column: "EventRequestId",
                principalTable: "EventRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
