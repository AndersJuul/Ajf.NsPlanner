using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class tablerelations14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Target",
                table: "Periods",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Periods_Target",
                table: "Periods",
                column: "Target",
                unique: true,
                filter: "[Target] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Periods_Target",
                table: "Periods");

            migrationBuilder.AlterColumn<string>(
                name: "Target",
                table: "Periods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
