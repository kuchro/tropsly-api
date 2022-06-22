using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tropsly_api.Migrations
{
    public partial class DeliveryOptionsAndOrdersProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryOptions",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeliveryName = table.Column<string>(type: "text", nullable: false),
                    DeliveryPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExtraOptions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOptions", x => x.DeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "Product_Orders",
                columns: table => new
                {
                    product_order_id = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    DeliveryOptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Orders", x => x.product_order_id);
                    table.ForeignKey(
                        name: "FK_Product_Orders_DeliveryOptions_product_order_id",
                        column: x => x.product_order_id,
                        principalTable: "DeliveryOptions",
                        principalColumn: "DeliveryId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "customer_personal",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    ProductOrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_personal", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_customer_personal_Product_Orders_ProductOrderId",
                        column: x => x.ProductOrderId,
                        principalTable: "Product_Orders",
                        principalColumn: "product_order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductOrder",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductOrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductOrder", x => new { x.ProductId, x.ProductOrderId });
                    table.ForeignKey(
                        name: "FK_ProductProductOrder_Product_Orders_ProductOrderId",
                        column: x => x.ProductOrderId,
                        principalTable: "Product_Orders",
                        principalColumn: "product_order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductOrder_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    StreetName = table.Column<string>(type: "text", nullable: false),
                    FlatNumber = table.Column<string>(type: "text", nullable: true),
                    HouseNumber = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: true),
                    CustomerPersonalDataId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_customer_personal_AddressId",
                        column: x => x.AddressId,
                        principalTable: "customer_personal",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_personal_ProductOrderId",
                table: "customer_personal",
                column: "ProductOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductOrder_ProductOrderId",
                table: "ProductProductOrder",
                column: "ProductOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "ProductProductOrder");

            migrationBuilder.DropTable(
                name: "customer_personal");

            migrationBuilder.DropTable(
                name: "Product_Orders");

            migrationBuilder.DropTable(
                name: "DeliveryOptions");
        }
    }
}
