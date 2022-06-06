using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bible2PPT.Services.BuildService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Template_FileName = table.Column<string>(type: "TEXT", nullable: false),
                    Template_BookNameVisible = table.Column<int>(type: "INTEGER", nullable: false),
                    Template_BookAbbrVisible = table.Column<int>(type: "INTEGER", nullable: false),
                    Template_ChapterNumberVisible = table.Column<int>(type: "INTEGER", nullable: false),
                    Template_NumberOfVerseLinesPerSlide = table.Column<int>(type: "INTEGER", nullable: false),
                    QueryString = table.Column<string>(type: "TEXT", nullable: false),
                    SplitChaptersIntoFiles = table.Column<bool>(type: "INTEGER", nullable: false),
                    OutputDestination = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bible",
                columns: table => new
                {
                    Sequence = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OnlineId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageCode = table.Column<string>(type: "TEXT", nullable: false),
                    JobId = table.Column<int>(type: "INTEGER", nullable: false),
                    SourceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bible", x => x.Sequence);
                    table.ForeignKey(
                        name: "FK_Bible_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bible_JobId",
                table: "Bible",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bible");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
