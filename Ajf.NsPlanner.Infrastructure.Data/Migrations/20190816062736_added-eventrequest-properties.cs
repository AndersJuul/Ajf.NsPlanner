using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class addedeventrequestproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Comments",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "ContactEmail",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "ContactPhone",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "DesiredDate",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "DesiredEvent",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "DesiredMeetingPoint",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "DesiredWhen",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "InstitutionOrSchool",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "ParticipantsAge",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "ParticipantsGroup",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "ParticipantsNumber",
                "EventRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "SchoolInstitueName",
                "EventRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Comments",
                "EventRequests");

            migrationBuilder.DropColumn(
                "ContactEmail",
                "EventRequests");

            migrationBuilder.DropColumn(
                "ContactPhone",
                "EventRequests");

            migrationBuilder.DropColumn(
                "DesiredDate",
                "EventRequests");

            migrationBuilder.DropColumn(
                "DesiredEvent",
                "EventRequests");

            migrationBuilder.DropColumn(
                "DesiredMeetingPoint",
                "EventRequests");

            migrationBuilder.DropColumn(
                "DesiredWhen",
                "EventRequests");

            migrationBuilder.DropColumn(
                "InstitutionOrSchool",
                "EventRequests");

            migrationBuilder.DropColumn(
                "ParticipantsAge",
                "EventRequests");

            migrationBuilder.DropColumn(
                "ParticipantsGroup",
                "EventRequests");

            migrationBuilder.DropColumn(
                "ParticipantsNumber",
                "EventRequests");

            migrationBuilder.DropColumn(
                "SchoolInstitueName",
                "EventRequests");
        }
    }
}