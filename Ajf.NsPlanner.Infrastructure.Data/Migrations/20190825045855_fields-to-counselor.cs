using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class fieldstocounselor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Counselors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Counselors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Counselors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Counselors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Counselors");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Counselors");
        }
    }
}
