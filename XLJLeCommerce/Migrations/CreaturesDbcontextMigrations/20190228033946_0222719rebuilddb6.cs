using Microsoft.EntityFrameworkCore.Migrations;

namespace XLJLeCommerce.Migrations.CreaturesDbcontextMigrations
{
    public partial class _0222719rebuilddb6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ShoppingCartTable",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_ProductID",
                table: "ShoppingCartTable",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartTable_Products_ProductID",
                table: "ShoppingCartTable",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartTable_Products_ProductID",
                table: "ShoppingCartTable");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartTable_ProductID",
                table: "ShoppingCartTable");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ShoppingCartTable");
        }
    }
}
