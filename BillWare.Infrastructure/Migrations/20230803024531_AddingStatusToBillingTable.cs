using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingStatusToBillingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillingStatus",
                table: "Billings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingStatus",
                table: "Billings");
        }
    }
}
