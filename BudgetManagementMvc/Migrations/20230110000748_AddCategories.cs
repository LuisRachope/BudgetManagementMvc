using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManagementMvc.Migrations
{
    public partial class AddCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Expense");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Expense",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Category_TypeId",
                table: "Expense");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Expense_TypeId",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Expense");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Expense",
                nullable: true);
        }
    }
}
