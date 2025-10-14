using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceOtpColumnsWithOtpToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenExpiry",
                table: "Customers",
                newName: "OtpExpiry");

            migrationBuilder.RenameColumn(
                name: "PasswordResetToken",
                table: "Customers",
                newName: "OtpCode");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 13, 10, 32, 9, 906, DateTimeKind.Utc).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 13, 10, 32, 9, 906, DateTimeKind.Utc).AddTicks(6464));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OtpExpiry",
                table: "Customers",
                newName: "TokenExpiry");

            migrationBuilder.RenameColumn(
                name: "OtpCode",
                table: "Customers",
                newName: "PasswordResetToken");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 10, 11, 48, 21, 704, DateTimeKind.Utc).AddTicks(619));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 10, 11, 48, 21, 704, DateTimeKind.Utc).AddTicks(623));
        }
    }
}
