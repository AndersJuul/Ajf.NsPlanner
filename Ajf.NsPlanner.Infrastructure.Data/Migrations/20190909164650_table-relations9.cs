using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class tablerelations9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_EventRequest_Id",
                table: "Assignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_EventRequest_Id",
                table: "Assignments",
                column: "Id",
                principalTable: "EventRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
