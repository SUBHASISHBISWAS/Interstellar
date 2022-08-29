using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expense.Infrastructure.Migrations
{
    public partial class ExpenseTableFieldUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "Transactions",
                newName: "ExpenseType");

            migrationBuilder.RenameColumn(
                name: "TransactionDecription",
                table: "Transactions",
                newName: "ExpenseDecription");

            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                table: "Transactions",
                newName: "ExpenseDate");

            migrationBuilder.RenameColumn(
                name: "TransactionCard",
                table: "Transactions",
                newName: "ExpenseCardId");

            migrationBuilder.RenameColumn(
                name: "TransactionAmout",
                table: "Transactions",
                newName: "ExpenseAmount");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "ExpenseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseType",
                table: "Transactions",
                newName: "TransactionType");

            migrationBuilder.RenameColumn(
                name: "ExpenseDecription",
                table: "Transactions",
                newName: "TransactionDecription");

            migrationBuilder.RenameColumn(
                name: "ExpenseDate",
                table: "Transactions",
                newName: "TransactionDate");

            migrationBuilder.RenameColumn(
                name: "ExpenseCardId",
                table: "Transactions",
                newName: "TransactionCard");

            migrationBuilder.RenameColumn(
                name: "ExpenseAmount",
                table: "Transactions",
                newName: "TransactionAmout");

            migrationBuilder.RenameColumn(
                name: "ExpenseId",
                table: "Transactions",
                newName: "TransactionId");
        }
    }
}
