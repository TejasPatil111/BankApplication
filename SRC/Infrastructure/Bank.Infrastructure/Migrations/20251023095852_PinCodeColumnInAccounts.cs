using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PinCodeColumnInAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "pincode",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 23, 9, 58, 50, 933, DateTimeKind.Utc).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 23, 9, 58, 50, 933, DateTimeKind.Utc).AddTicks(8336));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pincode",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 23, 5, 31, 7, 485, DateTimeKind.Utc).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 23, 5, 31, 7, 485, DateTimeKind.Utc).AddTicks(7552));
        }
    }
}
