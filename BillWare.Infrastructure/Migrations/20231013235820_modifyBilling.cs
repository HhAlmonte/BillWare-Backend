using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyBilling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Costumers_CostumerId",
                table: "Billings");

            migrationBuilder.AlterColumn<int>(
                name: "CostumerId",
                table: "Billings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "CostumerId",
                table: "Billings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Costumers_CostumerId",
                table: "Billings",
                column: "CostumerId",
                principalTable: "Costumers",
                principalColumn: "Id");
        }
    }
}
