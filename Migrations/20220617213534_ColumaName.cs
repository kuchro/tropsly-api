using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tropsly_api.Migrations
{
    public partial class ColumaName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "comment_id",
                table: "comment_section",
                newName: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "comment_section",
                newName: "comment_id");
        }
    }
}
