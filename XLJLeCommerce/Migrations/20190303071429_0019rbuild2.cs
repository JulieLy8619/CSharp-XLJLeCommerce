using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XLJLeCommerce.Migrations
{
    public partial class _0019rbuild2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderedItemsID",
                table: "ShoppingCartTable",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTable", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderedItemsTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(nullable: false),
                    ShoppingCartItemID = table.Column<int>(nullable: false),
                    CartID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedItemsTable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderedItemsTable_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderedItemsTable_OrderTable_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedItemsTable_ShoppingCartTable_ShoppingCartItemID",
                        column: x => x.ShoppingCartItemID,
                        principalTable: "ShoppingCartTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_OrderedItemsID",
                table: "ShoppingCartTable",
                column: "OrderedItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemsTable_CartID",
                table: "OrderedItemsTable",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemsTable_OrderID",
                table: "OrderedItemsTable",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemsTable_ShoppingCartItemID",
                table: "OrderedItemsTable",
                column: "ShoppingCartItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartTable_OrderedItemsTable_OrderedItemsID",
                table: "ShoppingCartTable",
                column: "OrderedItemsID",
                principalTable: "OrderedItemsTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartTable_OrderedItemsTable_OrderedItemsID",
                table: "ShoppingCartTable");

            migrationBuilder.DropTable(
                name: "OrderedItemsTable");

            migrationBuilder.DropTable(
                name: "OrderTable");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartTable_OrderedItemsID",
                table: "ShoppingCartTable");

            migrationBuilder.DropColumn(
                name: "OrderedItemsID",
                table: "ShoppingCartTable");
        }
    }
}
