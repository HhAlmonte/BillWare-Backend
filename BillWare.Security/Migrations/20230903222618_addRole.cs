using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BillWare.Infrastructure.Security.Migrations
{
    /// <inheritdoc />
    public partial class addRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79ba8e3f-5c28-42cb-a03e-babcfb0b5bd8", null, "Administrator", "ADMINISTRATOR" },
                    { "8c26c17c-ffe7-43ad-a3b3-b6d50ca71a63", null, "Operator", "OPERATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79ba8e3f-5c28-42cb-a03e-babcfb0b5bd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c26c17c-ffe7-43ad-a3b3-b6d50ca71a63");
        }
    }
}
