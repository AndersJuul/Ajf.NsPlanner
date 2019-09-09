using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class tablerelations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRequest_Assignments_AssignmentId",
                table: "EventRequest");

            migrationBuilder.DropIndex(
                name: "IX_EventRequest_AssignmentId",
                table: "EventRequest");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "EventRequest");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_EventRequest_Id",
                table: "Assignments",
                column: "Id",
                principalTable: "EventRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_EventRequest_Id",
                table: "Assignments");

            migrationBuilder.AddColumn<Guid>(
                name: "AssignmentId",
                table: "EventRequest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRequest_AssignmentId",
                table: "EventRequest",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRequest_Assignments_AssignmentId",
                table: "EventRequest",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
