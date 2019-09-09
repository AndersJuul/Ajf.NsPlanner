using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class tablerelations7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Periods_PeriodId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRequest_Periods_PeriodId",
                table: "EventRequest");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_PeriodId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Assignments");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRequest_Periods_PeriodId",
                table: "EventRequest",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRequest_Periods_PeriodId",
                table: "EventRequest");

            migrationBuilder.AddColumn<Guid>(
                name: "PeriodId",
                table: "Assignments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_PeriodId",
                table: "Assignments",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Periods_PeriodId",
                table: "Assignments",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRequest_Periods_PeriodId",
                table: "EventRequest",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
