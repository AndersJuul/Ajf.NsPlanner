using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class tablerelations11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_EventRequest_EventRequestId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_EventRequestId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "EventRequestId",
                table: "Assignments");

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
                name: "EventRequestId",
                table: "Assignments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_EventRequestId",
                table: "Assignments",
                column: "EventRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_EventRequest_EventRequestId",
                table: "Assignments",
                column: "EventRequestId",
                principalTable: "EventRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
