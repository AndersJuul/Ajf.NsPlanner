using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class tablerelations5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRequest_Periods_PeriodId",
                table: "EventRequest");

            migrationBuilder.DropIndex(
                name: "IX_EventRequest_PeriodId",
                table: "EventRequest");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "EventRequest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PeriodId",
                table: "EventRequest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRequest_PeriodId",
                table: "EventRequest",
                column: "PeriodId");

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
