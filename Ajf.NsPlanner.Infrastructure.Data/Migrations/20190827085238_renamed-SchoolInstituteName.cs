using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class renamedSchoolInstituteName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolInstitueName",
                table: "EventRequests");

            migrationBuilder.AddColumn<string>(
                name: "SchoolInstituteName",
                table: "EventRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolInstituteName",
                table: "EventRequests");

            migrationBuilder.AddColumn<string>(
                name: "SchoolInstitueName",
                table: "EventRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
