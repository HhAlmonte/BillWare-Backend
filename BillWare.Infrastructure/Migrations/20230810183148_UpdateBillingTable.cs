using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBillingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingItems_Billings_BillingEntityId",
                table: "BillingItems");

            migrationBuilder.DropIndex(
                name: "IX_BillingItems_BillingEntityId",
                table: "BillingItems");

            migrationBuilder.DropColumn(
                name: "BillingType",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "BillingEntityId",
                table: "BillingItems");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "BillingItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "BillingItems",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumberId",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerName",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPriceWithTax",
                table: "Billings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTax",
                table: "Billings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "BillingItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BillingId",
                table: "BillingItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Tax",
                table: "BillingItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_BillingItems_BillingId",
                table: "BillingItems",
                column: "BillingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingItems_Billings_BillingId",
                table: "BillingItems",
                column: "BillingId",
                principalTable: "Billings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingItems_Billings_BillingId",
                table: "BillingItems");

            migrationBuilder.DropIndex(
                name: "IX_BillingItems_BillingId",
                table: "BillingItems");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "SellerName",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "TotalPriceWithTax",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "TotalTax",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BillingItems");

            migrationBuilder.DropColumn(
                name: "BillingId",
                table: "BillingItems");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "BillingItems");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "BillingItems",
                newName: "ItemName");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "BillingItems",
                newName: "ItemId");

            migrationBuilder.AddColumn<int>(
                name: "BillingType",
                table: "Billings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillingEntityId",
                table: "BillingItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillingItems_BillingEntityId",
                table: "BillingItems",
                column: "BillingEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingItems_Billings_BillingEntityId",
                table: "BillingItems",
                column: "BillingEntityId",
                principalTable: "Billings",
                principalColumn: "Id");
        }
    }
}
