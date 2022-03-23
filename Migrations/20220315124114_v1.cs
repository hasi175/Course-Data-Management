using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseDataManagement.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "externalModeration",
                columns: table => new
                {
                    CourseID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfExternalModerator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePassedToExternalModerator = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfExternalmoderatorReport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfResponseToReport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextDueDateForExternalModeration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendEmailNotificationTo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_externalModeration", x => x.CourseID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "externalModeration");
        }
    }
}
