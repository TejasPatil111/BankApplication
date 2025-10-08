using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParentTransactionAndTypeToTransfers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentTransactionId",
                table: "Transfers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionType",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 8, 7, 27, 57, 419, DateTimeKind.Utc).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 8, 7, 27, 57, 419, DateTimeKind.Utc).AddTicks(9246));

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_ParentTransactionId",
                table: "Transfers",
                column: "ParentTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Transfers_ParentTransactionId",
                table: "Transfers",
                column: "ParentTransactionId",
                principalTable: "Transfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Transfers_ParentTransactionId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_ParentTransactionId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "ParentTransactionId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transfers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 7, 7, 43, 35, 718, DateTimeKind.Utc).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 10, 7, 7, 43, 35, 718, DateTimeKind.Utc).AddTicks(8885));
        }
    }
}
