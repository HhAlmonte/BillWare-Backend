using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_CategoryId",
                table: "Inventories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Categories_CategoryId",
                table: "Inventories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Categories_CategoryId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_CategoryId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Inventories");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
