using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FromAndToBalancecolumnInTransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BalanceAfterTransaction",
                table: "Transfers",
                newName: "ToBalanceAfter");

            migrationBuilder.AddColumn<decimal>(
                name: "FromBalanceAfter",
                table: "Transfers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromBalanceAfter",
                table: "Transfers");

            migrationBuilder.RenameColumn(
                name: "ToBalanceAfter",
                table: "Transfers",
                newName: "BalanceAfterTransaction");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 23, 4, 5, 24, 600, DateTimeKind.Utc).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 23, 4, 5, 24, 600, DateTimeKind.Utc).AddTicks(4567));
        }
    }
}
