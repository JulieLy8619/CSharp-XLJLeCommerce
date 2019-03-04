using Microsoft.EntityFrameworkCore.Migrations;

namespace XLJLeCommerce.Migrations
{
    public partial class _022819rebild11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartItemID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartItemID",
                table: "Products",
                column: "ShoppingCartItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCartTable_ShoppingCartItemID",
                table: "Products",
                column: "ShoppingCartItemID",
                principalTable: "ShoppingCartTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCartTable_ShoppingCartItemID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingCartItemID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingCartItemID",
                table: "Products");
        }
    }
}
