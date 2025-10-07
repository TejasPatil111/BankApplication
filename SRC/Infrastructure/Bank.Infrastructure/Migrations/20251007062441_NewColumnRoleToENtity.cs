using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnRoleToENtity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GetAccountNoWithTransactionDto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromAC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToAC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetAccountNoWithTransactionDto", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedOnUtc", "Role" },
                values: new object[] { new DateTime(2025, 10, 7, 6, 24, 40, 208, DateTimeKind.Utc).AddTicks(4041), "User" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedOnUtc", "Role" },
                values: new object[] { new DateTime(2025, 10, 7, 6, 24, 40, 208, DateTimeKind.Utc).AddTicks(4045), "User" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetAccountNoWithTransactionDto");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 9, 15, 13, 57, 34, 757, DateTimeKind.Utc).AddTicks(2946));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 9, 15, 13, 57, 34, 757, DateTimeKind.Utc).AddTicks(2951));
        }
    }
}
