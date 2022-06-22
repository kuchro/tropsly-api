using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tropsly_api.Migrations
{
    public partial class CascadeOnComm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_section_Product_ProductId",
                table: "comment_section");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_section_Product_ProductId",
                table: "comment_section",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_section_Product_ProductId",
                table: "comment_section");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_section_Product_ProductId",
                table: "comment_section",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
