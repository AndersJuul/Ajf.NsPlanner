using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class tablerelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_EventRequests_EventRequestId",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRequests",
                table: "EventRequests");

            migrationBuilder.RenameTable(
                name: "EventRequests",
                newName: "EventRequest");

            migrationBuilder.AddColumn<Guid>(
                name: "PeriodId",
                table: "Assignments",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssignmentId",
                table: "EventRequest",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRequest",
                table: "EventRequest",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableDates_PeriodId",
                table: "AvailableDates",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_PeriodId",
                table: "Assignments",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequest_AssignmentId",
                table: "EventRequest",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_EventRequest_EventRequestId",
                table: "Assignments",
                column: "EventRequestId",
                principalTable: "EventRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Periods_PeriodId",
                table: "Assignments",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableDates_Periods_PeriodId",
                table: "AvailableDates",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRequest_Assignments_AssignmentId",
                table: "EventRequest",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_EventRequest_EventRequestId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Periods_PeriodId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_AvailableDates_Periods_PeriodId",
                table: "AvailableDates");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRequest_Assignments_AssignmentId",
                table: "EventRequest");

            migrationBuilder.DropIndex(
                name: "IX_AvailableDates_PeriodId",
                table: "AvailableDates");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_PeriodId",
                table: "Assignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRequest",
                table: "EventRequest");

            migrationBuilder.DropIndex(
                name: "IX_EventRequest_AssignmentId",
                table: "EventRequest");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "EventRequest");

            migrationBuilder.RenameTable(
                name: "EventRequest",
                newName: "EventRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRequests",
                table: "EventRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_EventRequests_EventRequestId",
                table: "Assignments",
                column: "EventRequestId",
                principalTable: "EventRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
