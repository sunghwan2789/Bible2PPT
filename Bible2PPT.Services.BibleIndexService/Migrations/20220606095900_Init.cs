using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bible2PPT.Services.BibleIndexService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookInfos",
                columns: table => new
                {
                    Key = table.Column<int>(type: "INTEGER", nullable: false),
                    Kind = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageCode = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    IsPrimary = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInfos", x => new { x.Key, x.Kind, x.LanguageCode, x.Version });
                });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 1, 0, "ko", "개역 성경", false, "창세기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 1, 0, "ko", "새번역 성경", false, "창세기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 1, 1, "ko", "개역 성경", false, "창" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 1, 1, "ko", "새번역 성경", false, "창" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 2, 0, "ko", "개역 성경", false, "출애굽기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 2, 0, "ko", "새번역 성경", false, "출애굽기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 2, 1, "ko", "개역 성경", false, "출" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 2, 1, "ko", "새번역 성경", false, "출" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 3, 0, "ko", "개역 성경", false, "레위기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 3, 0, "ko", "새번역 성경", false, "레위기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 3, 1, "ko", "개역 성경", false, "레" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 3, 1, "ko", "새번역 성경", false, "레" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 4, 0, "ko", "개역 성경", false, "민수기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 4, 0, "ko", "새번역 성경", false, "민수기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 4, 1, "ko", "개역 성경", false, "민" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 4, 1, "ko", "새번역 성경", false, "민" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 5, 0, "ko", "개역 성경", false, "신명기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 5, 0, "ko", "새번역 성경", false, "신명기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 5, 1, "ko", "개역 성경", false, "신" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 5, 1, "ko", "새번역 성경", false, "신" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 6, 0, "ko", "개역 성경", false, "여호수아" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 6, 0, "ko", "새번역 성경", false, "여호수아" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 6, 1, "ko", "개역 성경", false, "수" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 6, 1, "ko", "새번역 성경", false, "수" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 7, 0, "ko", "개역 성경", false, "사사기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 7, 0, "ko", "새번역 성경", false, "사사기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 7, 1, "ko", "개역 성경", false, "삿" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 7, 1, "ko", "새번역 성경", false, "삿" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 8, 0, "ko", "개역 성경", false, "룻기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 8, 0, "ko", "새번역 성경", false, "룻기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 8, 1, "ko", "개역 성경", false, "룻" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 8, 1, "ko", "새번역 성경", false, "룻" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 9, 0, "ko", "개역 성경", false, "사무엘상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 9, 0, "ko", "새번역 성경", false, "사무엘상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 9, 1, "ko", "개역 성경", false, "삼상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 9, 1, "ko", "새번역 성경", false, "삼상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 10, 0, "ko", "개역 성경", false, "사무엘하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 10, 0, "ko", "새번역 성경", false, "사무엘하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 10, 1, "ko", "개역 성경", false, "삼하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 10, 1, "ko", "새번역 성경", false, "삼하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 11, 0, "ko", "개역 성경", false, "열왕기상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 11, 0, "ko", "새번역 성경", false, "열왕기상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 11, 1, "ko", "개역 성경", false, "왕상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 11, 1, "ko", "새번역 성경", false, "왕상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 12, 0, "ko", "개역 성경", false, "열왕기하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 12, 0, "ko", "새번역 성경", false, "열왕기하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 12, 1, "ko", "개역 성경", false, "왕하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 12, 1, "ko", "새번역 성경", false, "왕하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 13, 0, "ko", "개역 성경", false, "역대상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 13, 0, "ko", "새번역 성경", false, "역대상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 13, 1, "ko", "개역 성경", false, "대상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 13, 1, "ko", "새번역 성경", false, "대상" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 14, 0, "ko", "개역 성경", false, "역대하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 14, 0, "ko", "새번역 성경", false, "역대하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 14, 1, "ko", "개역 성경", false, "대하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 14, 1, "ko", "새번역 성경", false, "대하" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 15, 0, "ko", "개역 성경", false, "에스라" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 15, 0, "ko", "새번역 성경", false, "에스라" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 15, 1, "ko", "개역 성경", false, "스" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 15, 1, "ko", "새번역 성경", false, "라" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 16, 0, "ko", "개역 성경", false, "느헤미야" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 16, 0, "ko", "새번역 성경", false, "느헤미야" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 16, 1, "ko", "개역 성경", false, "느" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 16, 1, "ko", "새번역 성경", false, "느" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 17, 0, "ko", "개역 성경", false, "에스더" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 17, 0, "ko", "새번역 성경", false, "에스더" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 17, 1, "ko", "개역 성경", false, "에" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 17, 1, "ko", "새번역 성경", false, "더" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 18, 0, "ko", "개역 성경", false, "욥기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 18, 0, "ko", "새번역 성경", false, "욥기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 18, 1, "ko", "개역 성경", false, "욥" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 18, 1, "ko", "새번역 성경", false, "욥" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 19, 0, "ko", "개역 성경", false, "시편" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 19, 0, "ko", "새번역 성경", false, "시편" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 19, 1, "ko", "개역 성경", false, "시" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 19, 1, "ko", "새번역 성경", false, "시" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 20, 0, "ko", "개역 성경", false, "잠언" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 20, 0, "ko", "새번역 성경", false, "잠언" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 20, 1, "ko", "개역 성경", false, "잠" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 20, 1, "ko", "새번역 성경", false, "잠" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 21, 0, "ko", "개역 성경", false, "전도서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 21, 0, "ko", "새번역 성경", false, "전도서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 21, 1, "ko", "개역 성경", false, "전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 21, 1, "ko", "새번역 성경", false, "전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 22, 0, "ko", "개역 성경", false, "아가" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 22, 0, "ko", "새번역 성경", false, "아가" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 22, 1, "ko", "개역 성경", false, "아" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 22, 1, "ko", "새번역 성경", false, "아" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 23, 0, "ko", "개역 성경", false, "이사야" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 23, 0, "ko", "새번역 성경", false, "이사야" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 23, 1, "ko", "개역 성경", false, "사" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 23, 1, "ko", "새번역 성경", false, "사" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 24, 0, "ko", "개역 성경", false, "예레미야" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 24, 0, "ko", "새번역 성경", false, "예레미야" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 24, 1, "ko", "개역 성경", false, "렘" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 24, 1, "ko", "새번역 성경", false, "렘" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 25, 0, "ko", "개역 성경", false, "예레미야애가" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 25, 0, "ko", "새번역 성경", false, "예레미야애가" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 25, 1, "ko", "개역 성경", false, "애" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 25, 1, "ko", "새번역 성경", false, "애" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 26, 0, "ko", "개역 성경", false, "에스겔" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 26, 0, "ko", "새번역 성경", false, "에스겔" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 26, 1, "ko", "개역 성경", false, "겔" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 26, 1, "ko", "새번역 성경", false, "겔" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 27, 0, "ko", "개역 성경", false, "다니엘" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 27, 0, "ko", "새번역 성경", false, "다니엘" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 27, 1, "ko", "개역 성경", false, "단" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 27, 1, "ko", "새번역 성경", false, "단" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 28, 0, "ko", "개역 성경", false, "호세아" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 28, 0, "ko", "새번역 성경", false, "호세아" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 28, 1, "ko", "개역 성경", false, "호" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 28, 1, "ko", "새번역 성경", false, "호" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 29, 0, "ko", "개역 성경", false, "요엘" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 29, 0, "ko", "새번역 성경", false, "요엘" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 29, 1, "ko", "개역 성경", false, "욜" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 29, 1, "ko", "새번역 성경", false, "욜" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 30, 0, "ko", "개역 성경", false, "아모스" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 30, 0, "ko", "새번역 성경", false, "아모스" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 30, 1, "ko", "개역 성경", false, "암" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 30, 1, "ko", "새번역 성경", false, "암" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 31, 0, "ko", "개역 성경", false, "오바댜" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 31, 0, "ko", "새번역 성경", false, "오바댜" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 31, 1, "ko", "개역 성경", false, "옵" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 31, 1, "ko", "새번역 성경", false, "옵" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 32, 0, "ko", "개역 성경", false, "요나" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 32, 0, "ko", "새번역 성경", false, "요나" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 32, 1, "ko", "개역 성경", false, "욘" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 32, 1, "ko", "새번역 성경", false, "욘" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 33, 0, "ko", "개역 성경", false, "미가" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 33, 0, "ko", "새번역 성경", false, "미가" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 33, 1, "ko", "개역 성경", false, "미" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 33, 1, "ko", "새번역 성경", false, "미" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 34, 0, "ko", "개역 성경", false, "나홈" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 34, 0, "ko", "새번역 성경", false, "나홈" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 34, 1, "ko", "개역 성경", false, "나" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 34, 1, "ko", "새번역 성경", false, "나" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 35, 0, "ko", "개역 성경", false, "하박국" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 35, 0, "ko", "새번역 성경", false, "하박국" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 35, 1, "ko", "개역 성경", false, "합" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 35, 1, "ko", "새번역 성경", false, "합" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 36, 0, "ko", "개역 성경", false, "스바냐" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 36, 0, "ko", "새번역 성경", false, "스바냐" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 36, 1, "ko", "개역 성경", false, "습" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 36, 1, "ko", "새번역 성경", false, "습" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 37, 0, "ko", "개역 성경", false, "학개" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 37, 0, "ko", "새번역 성경", false, "학개" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 37, 1, "ko", "개역 성경", false, "학" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 37, 1, "ko", "새번역 성경", false, "학" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 38, 0, "ko", "개역 성경", false, "스가랴" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 38, 0, "ko", "새번역 성경", false, "스가랴" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 38, 1, "ko", "개역 성경", false, "슥" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 38, 1, "ko", "새번역 성경", false, "슥" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 39, 0, "ko", "개역 성경", false, "말라기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 39, 0, "ko", "새번역 성경", false, "말라기" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 39, 1, "ko", "개역 성경", false, "말" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 39, 1, "ko", "새번역 성경", false, "말" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 55, 0, "ko", "개역 성경", false, "마태복음" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 55, 0, "ko", "새번역 성경", false, "마태복음" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 55, 1, "ko", "개역 성경", false, "마" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 55, 1, "ko", "새번역 성경", false, "마" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 56, 0, "ko", "개역 성경", false, "마가복음" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 56, 0, "ko", "새번역 성경", false, "마가복음" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 56, 1, "ko", "개역 성경", false, "막" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 56, 1, "ko", "새번역 성경", false, "막" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 57, 0, "ko", "개역 성경", false, "누가복음" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 57, 0, "ko", "새번역 성경", false, "누가복음" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 57, 1, "ko", "개역 성경", false, "눅" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 57, 1, "ko", "새번역 성경", false, "눅" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 58, 0, "ko", "개역 성경", false, "요한복음" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 58, 0, "ko", "새번역 성경", false, "요한복음" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 58, 1, "ko", "개역 성경", false, "요" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 58, 1, "ko", "새번역 성경", false, "요" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 59, 0, "ko", "개역 성경", false, "사도행전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 59, 0, "ko", "새번역 성경", false, "사도행전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 59, 1, "ko", "개역 성경", false, "행" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 59, 1, "ko", "새번역 성경", false, "행" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 60, 0, "ko", "개역 성경", false, "로마서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 60, 0, "ko", "새번역 성경", false, "로마서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 60, 1, "ko", "개역 성경", false, "롬" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 60, 1, "ko", "새번역 성경", false, "롬" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 61, 0, "ko", "개역 성경", false, "고린도전서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 61, 0, "ko", "새번역 성경", false, "고린도전서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 61, 1, "ko", "개역 성경", false, "고전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 61, 1, "ko", "새번역 성경", false, "고전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 62, 0, "ko", "개역 성경", false, "고린도후서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 62, 0, "ko", "새번역 성경", false, "고린도후서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 62, 1, "ko", "개역 성경", false, "고후" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 62, 1, "ko", "새번역 성경", false, "고후" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 63, 0, "ko", "개역 성경", false, "갈라디아서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 63, 0, "ko", "새번역 성경", false, "갈라디아서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 63, 1, "ko", "개역 성경", false, "갈" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 63, 1, "ko", "새번역 성경", false, "갈" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 64, 0, "ko", "개역 성경", false, "에베소서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 64, 0, "ko", "새번역 성경", false, "에베소서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 64, 1, "ko", "개역 성경", false, "엡" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 64, 1, "ko", "새번역 성경", false, "엡" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 65, 0, "ko", "개역 성경", false, "빌립보서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 65, 0, "ko", "새번역 성경", false, "빌립보서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 65, 1, "ko", "개역 성경", false, "빌" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 65, 1, "ko", "새번역 성경", false, "빌" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 66, 0, "ko", "개역 성경", false, "골로새서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 66, 0, "ko", "새번역 성경", false, "골로새서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 66, 1, "ko", "개역 성경", false, "골" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 66, 1, "ko", "새번역 성경", false, "골" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 67, 0, "ko", "개역 성경", false, "데살로니가전서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 67, 0, "ko", "새번역 성경", false, "데살로니가전서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 67, 1, "ko", "개역 성경", false, "살전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 67, 1, "ko", "새번역 성경", false, "살전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 68, 0, "ko", "개역 성경", false, "데살로니가후서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 68, 0, "ko", "새번역 성경", false, "데살로니가후서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 68, 1, "ko", "개역 성경", false, "살후" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 68, 1, "ko", "새번역 성경", false, "살후" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 69, 0, "ko", "개역 성경", false, "디모데전서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 69, 0, "ko", "새번역 성경", false, "디모데전서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 69, 1, "ko", "개역 성경", false, "딤전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 69, 1, "ko", "새번역 성경", false, "딤전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 70, 0, "ko", "개역 성경", false, "디모데후서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 70, 0, "ko", "새번역 성경", false, "디모데후서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 70, 1, "ko", "개역 성경", false, "딤후" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 70, 1, "ko", "새번역 성경", false, "딤후" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 71, 0, "ko", "개역 성경", false, "디도서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 71, 0, "ko", "새번역 성경", false, "디도서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 71, 1, "ko", "개역 성경", false, "딛" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 71, 1, "ko", "새번역 성경", false, "딛" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 72, 0, "ko", "개역 성경", false, "빌레몬서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 72, 0, "ko", "새번역 성경", false, "빌레몬서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 72, 1, "ko", "개역 성경", false, "몬" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 72, 1, "ko", "새번역 성경", false, "몬" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 73, 0, "ko", "개역 성경", false, "히브리서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 73, 0, "ko", "새번역 성경", false, "히브리서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 73, 1, "ko", "개역 성경", false, "히" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 73, 1, "ko", "새번역 성경", false, "히" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 74, 0, "ko", "개역 성경", false, "야고보서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 74, 0, "ko", "새번역 성경", false, "야고보서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 74, 1, "ko", "개역 성경", false, "약" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 74, 1, "ko", "새번역 성경", false, "약" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 75, 0, "ko", "개역 성경", false, "베드로전서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 75, 0, "ko", "새번역 성경", false, "베드로전서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 75, 1, "ko", "개역 성경", false, "벧전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 75, 1, "ko", "새번역 성경", false, "벧전" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 76, 0, "ko", "개역 성경", false, "베드로후서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 76, 0, "ko", "새번역 성경", false, "베드로후서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 76, 1, "ko", "개역 성경", false, "벧후" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 76, 1, "ko", "새번역 성경", false, "벧후" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 77, 0, "ko", "개역 성경", false, "요한일서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 77, 0, "ko", "새번역 성경", false, "요한일서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 77, 1, "ko", "개역 성경", false, "요일" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 77, 1, "ko", "새번역 성경", false, "요일" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 78, 0, "ko", "개역 성경", false, "요한이서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 78, 0, "ko", "새번역 성경", false, "요한이서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 78, 1, "ko", "개역 성경", false, "요이" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 78, 1, "ko", "새번역 성경", false, "요이" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 79, 0, "ko", "개역 성경", false, "요한삼서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 79, 0, "ko", "새번역 성경", false, "요한삼서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 79, 1, "ko", "개역 성경", false, "요삼" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 79, 1, "ko", "새번역 성경", false, "요삼" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 80, 0, "ko", "개역 성경", false, "유다서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 80, 0, "ko", "새번역 성경", false, "유다서" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 80, 1, "ko", "개역 성경", false, "유" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 80, 1, "ko", "새번역 성경", false, "유" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 81, 0, "ko", "개역 성경", false, "요한계시록" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 81, 0, "ko", "새번역 성경", false, "요한계시록" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 81, 1, "ko", "개역 성경", false, "계" });

            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "Key", "Kind", "LanguageCode", "Version", "IsPrimary", "Value" },
                values: new object[] { 81, 1, "ko", "새번역 성경", false, "계" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInfos");
        }
    }
}
