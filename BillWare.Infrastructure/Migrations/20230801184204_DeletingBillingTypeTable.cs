using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeletingBillingTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_BillingTypes_BillingTypeId",
                table: "Billings");

            migrationBuilder.DropTable(
                name: "BillingTypes");

            migrationBuilder.DropIndex(
                name: "IX_Billings_BillingTypeId",
                table: "Billings");

            migrationBuilder.RenameColumn(
                name: "BillingTypeId",
                table: "Billings",
                newName: "BillingType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BillingType",
                table: "Billings",
                newName: "BillingTypeId");

            migrationBuilder.CreateTable(
                name: "BillingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billings_BillingTypeId",
                table: "Billings",
                column: "BillingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_BillingTypes_BillingTypeId",
                table: "Billings",
                column: "BillingTypeId",
                principalTable: "BillingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
