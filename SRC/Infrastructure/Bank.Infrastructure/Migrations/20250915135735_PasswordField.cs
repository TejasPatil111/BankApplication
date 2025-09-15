using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PasswordField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedOnUtc", "Password" },
                values: new object[] { new DateTime(2025, 9, 15, 13, 57, 34, 757, DateTimeKind.Utc).AddTicks(2946), "tejas@123" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedOnUtc", "Email", "Password" },
                values: new object[] { new DateTime(2025, 9, 15, 13, 57, 34, 757, DateTimeKind.Utc).AddTicks(2951), "om123@gmail.com", "om@123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedOnUtc", "Password" },
                values: new object[] { new DateTime(2025, 9, 15, 13, 53, 35, 686, DateTimeKind.Utc).AddTicks(9922), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedOnUtc", "Email", "Password" },
                values: new object[] { new DateTime(2025, 9, 15, 13, 53, 35, 686, DateTimeKind.Utc).AddTicks(9928), "om@gmail.com", null });
        }
    }
}
