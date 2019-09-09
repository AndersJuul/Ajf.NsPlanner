using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class tablerelations15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PeriodId1",
                table: "EventRequest",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PeriodId",
                table: "AvailableDates",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRequest_PeriodId1",
                table: "EventRequest",
                column: "PeriodId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRequest_Periods_PeriodId1",
                table: "EventRequest",
                column: "PeriodId1",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRequest_Periods_PeriodId1",
                table: "EventRequest");

            migrationBuilder.DropIndex(
                name: "IX_EventRequest_PeriodId1",
                table: "EventRequest");

            migrationBuilder.DropColumn(
                name: "PeriodId1",
                table: "EventRequest");

            migrationBuilder.AlterColumn<Guid>(
                name: "PeriodId",
                table: "AvailableDates",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
