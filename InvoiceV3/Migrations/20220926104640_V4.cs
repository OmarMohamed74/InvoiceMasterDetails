using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceV3.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_Products_ProductId",
                table: "InvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceDetailsId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_InvoiceDetailsId",
                table: "Products",
                column: "InvoiceDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_InvoiceDetails_InvoiceDetailsId",
                table: "Products",
                column: "InvoiceDetailsId",
                principalTable: "InvoiceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_InvoiceDetails_InvoiceDetailsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_InvoiceDetailsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InvoiceDetailsId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Products_ProductId",
                table: "InvoiceDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
