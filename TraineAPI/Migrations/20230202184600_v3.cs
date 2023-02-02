using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineAPI.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_reports_ReportId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_ReportId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "posts");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reports_PostId",
                table: "reports",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_reports_posts_PostId",
                table: "reports",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reports_posts_PostId",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_reports_PostId",
                table: "reports");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "reports");

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_ReportId",
                table: "posts",
                column: "ReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_reports_ReportId",
                table: "posts",
                column: "ReportId",
                principalTable: "reports",
                principalColumn: "ReportId");
        }
    }
}
