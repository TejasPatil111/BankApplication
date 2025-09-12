using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ids_Guid_to_int : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    OpendOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyStatus = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LedgerEntiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false),
                    CorrelationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccuredOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Narrative = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerEntiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LedgerEntiries_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InitiatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Refrence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromAccountId = table.Column<int>(type: "int", nullable: false),
                    ToAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_Accounts_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Accounts_ToAccountId",
                        column: x => x.ToAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "CreatedOnUtc", "Email", "KeyStatus", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 11, 10, 15, 5, 277, DateTimeKind.Utc).AddTicks(9234), "tejas@gmail.com", true, "Tejas", 0 },
                    { 2, new DateTime(2025, 9, 11, 10, 15, 5, 277, DateTimeKind.Utc).AddTicks(9241), "om@gmail.com", true, "John Doe", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LedgerEntiries_AccountId",
                table: "LedgerEntiries",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_FromAccountId",
                table: "Transfers",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_ToAccountId",
                table: "Transfers",
                column: "ToAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "LedgerEntiries");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
