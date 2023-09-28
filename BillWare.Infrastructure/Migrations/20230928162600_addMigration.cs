using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "NumberId",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Billings");

            migrationBuilder.AlterColumn<string>(
                name: "SellerName",
                table: "Billings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "Billings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CostumerId",
                table: "Billings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Billings_CostumerId",
                table: "Billings",
                column: "CostumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Costumers_CostumerId",
                table: "Billings",
                column: "CostumerId",
                principalTable: "Costumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Costumers_CostumerId",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_Billings_CostumerId",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "CostumerId",
                table: "Billings");

            migrationBuilder.AlterColumn<string>(
                name: "SellerName",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
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
        }
    }
}
