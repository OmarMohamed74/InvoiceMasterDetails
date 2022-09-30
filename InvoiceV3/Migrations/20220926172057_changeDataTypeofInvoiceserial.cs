using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceV3.Migrations
{
    public partial class changeDataTypeofInvoiceserial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InvoiceSerial",
                table: "InvoiceMasters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "InvoiceSerial",
                table: "InvoiceMasters",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
