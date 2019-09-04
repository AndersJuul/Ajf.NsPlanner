using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ajf.NsPlanner.Infrastructure.Data.Migrations
{
    public partial class addedassignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Periods");

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventRequestId = table.Column<Guid>(nullable: true),
                    SchoolEventId = table.Column<Guid>(nullable: true),
                    CounselorId = table.Column<Guid>(nullable: true),
                    PlaceId = table.Column<Guid>(nullable: true),
                    DateTimeOfStart = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Counselors_CounselorId",
                        column: x => x.CounselorId,
                        principalTable: "Counselors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_EventRequests_EventRequestId",
                        column: x => x.EventRequestId,
                        principalTable: "EventRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_SchoolEvent_SchoolEventId",
                        column: x => x.SchoolEventId,
                        principalTable: "SchoolEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CounselorId",
                table: "Assignments",
                column: "CounselorId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_EventRequestId",
                table: "Assignments",
                column: "EventRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_PlaceId",
                table: "Assignments",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SchoolEventId",
                table: "Assignments",
                column: "SchoolEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "SchoolEvent");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Periods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
