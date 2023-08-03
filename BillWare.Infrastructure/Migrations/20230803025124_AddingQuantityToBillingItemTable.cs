﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillWare.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingQuantityToBillingItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BillingItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BillingItems");
        }
    }
}