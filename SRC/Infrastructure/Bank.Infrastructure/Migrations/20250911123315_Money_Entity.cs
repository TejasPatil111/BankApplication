using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Money_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromAccountId = table.Column<int>(type: "int", nullable: false),
                    ToAccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InitiatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Refrences = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 9, 11, 12, 33, 14, 760, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 9, 11, 12, 33, 14, 760, DateTimeKind.Utc).AddTicks(9996));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 9, 11, 10, 15, 5, 277, DateTimeKind.Utc).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "id",
                keyValue: 2,
                column: "CreatedOnUtc",
                value: new DateTime(2025, 9, 11, 10, 15, 5, 277, DateTimeKind.Utc).AddTicks(9241));
        }
    }
}
