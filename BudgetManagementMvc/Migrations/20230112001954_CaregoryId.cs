using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManagementMvc.Migrations
{
    public partial class CaregoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Category_TypeId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_TypeId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Expense");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Expense",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CategoryId",
                table: "Expense",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Category_CategoryId",
                table: "Expense",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Category_CategoryId",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_CategoryId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Expense");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Expense",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expense_TypeId",
                table: "Expense",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Category_TypeId",
                table: "Expense",
                column: "TypeId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
