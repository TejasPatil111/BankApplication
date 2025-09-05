using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "CreatedOnUtc", "Email", "KeyStatus", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("a3c3b282-6b6e-4a85-8a3e-74e58a6a9b01"), new DateTime(2025, 9, 1, 14, 8, 45, 696, DateTimeKind.Utc).AddTicks(7433), "tejas@gmail.com", true, "Tejas", 0 },
                    { new Guid("b4d4c393-7c7f-5b96-9b4f-85f69b7b0c12"), new DateTime(2025, 9, 1, 14, 8, 45, 696, DateTimeKind.Utc).AddTicks(7440), "om@gmail.com", true, "John Doe", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: new Guid("a3c3b282-6b6e-4a85-8a3e-74e58a6a9b01"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: new Guid("b4d4c393-7c7f-5b96-9b4f-85f69b7b0c12"));
        }
    }
}
