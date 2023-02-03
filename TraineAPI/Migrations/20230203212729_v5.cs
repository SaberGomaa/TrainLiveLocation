using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineAPI.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_posts_PostId",
                table: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_posts_PostId",
                table: "comments",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_posts_PostId",
                table: "comments");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_posts_PostId",
                table: "comments",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "PostId");
        }
    }
}
