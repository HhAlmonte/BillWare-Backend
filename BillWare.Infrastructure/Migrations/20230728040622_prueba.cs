using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehiculoEntrance_VehiculoEntranceEntityId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehiculoEntranceEntityId",
                table: "Vehicles",
                newName: "VehicleEntranceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehiculoEntranceEntityId",
                table: "Vehicles",
                newName: "IX_Vehicles_VehicleEntranceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehiculoEntrance_VehicleEntranceEntityId",
                table: "Vehicles",
                column: "VehicleEntranceEntityId",
                principalTable: "VehiculoEntrance",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehiculoEntrance_VehicleEntranceEntityId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleEntranceEntityId",
                table: "Vehicles",
                newName: "VehiculoEntranceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehicleEntranceEntityId",
                table: "Vehicles",
                newName: "IX_Vehicles_VehiculoEntranceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehiculoEntrance_VehiculoEntranceEntityId",
                table: "Vehicles",
                column: "VehiculoEntranceEntityId",
                principalTable: "VehiculoEntrance",
                principalColumn: "Id");
        }
    }
}
