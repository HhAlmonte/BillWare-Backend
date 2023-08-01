using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTableForCostumer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Costumers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Costumers");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Costumers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "Costumers",
                newName: "NumberId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Costumers",
                newName: "FullName");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Costumers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "VehiculoEntrance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostumerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoEntrance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiculoEntrance_Costumers_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostumerId = table.Column<int>(type: "int", nullable: false),
                    VehiculoEntranceEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Costumers_CostumerId",
                        column: x => x.CostumerId,
                        principalTable: "Costumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehiculoEntrance_VehiculoEntranceEntityId",
                        column: x => x.VehiculoEntranceEntityId,
                        principalTable: "VehiculoEntrance",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CostumerId",
                table: "Vehicles",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehiculoEntranceEntityId",
                table: "Vehicles",
                column: "VehiculoEntranceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoEntrance_CostumerId",
                table: "VehiculoEntrance",
                column: "CostumerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehiculoEntrance");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Costumers",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "NumberId",
                table: "Costumers",
                newName: "TelephoneNumber");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Costumers",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Costumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Costumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Costumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Costumers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Costumers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Costumers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Costumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Costumers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
