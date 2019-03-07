using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XLJLeCommerce.Migrations.CreaturesDbcontextMigrations
{
    public partial class _030719rbuild27 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    Totalprice = table.Column<decimal>(nullable: false)
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
                    ProductID = table.Column<int>(nullable: false),
                    ProdQty = table.Column<int>(nullable: false),
                    CartID = table.Column<int>(nullable: true),
                    ShoppingCartItemID = table.Column<int>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    ProdQty = table.Column<int>(nullable: false),
                    OrderedItemsID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartTable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartTable_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartTable_OrderedItemsTable_OrderedItemsID",
                        column: x => x.OrderedItemsID,
                        principalTable: "OrderedItemsTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    VIPItem = table.Column<bool>(nullable: false),
                    OrderedItemsID = table.Column<int>(nullable: true),
                    ShoppingCartItemID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_OrderedItemsTable_OrderedItemsID",
                        column: x => x.OrderedItemsID,
                        principalTable: "OrderedItemsTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ShoppingCartTable_ShoppingCartItemID",
                        column: x => x.ShoppingCartItemID,
                        principalTable: "ShoppingCartTable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ImageURL", "Name", "OrderedItemsID", "Price", "ShoppingCartItemID", "Sku", "VIPItem" },
                values: new object[,]
                {
                    { 1, "The Unicorn is like a horse but has a magical horn that makes it more and better than a standard horse.", "/Assets/Unicorn.png", "Unicorn", null, 20m, null, "Unicorn1abc123", true },
                    { 2, "The Dragon is a powerful magical lizard. About 30 times the size of a normal lizard and has special powers like breaths fire.", "/Assets/Dragon2.png", "Dragon", null, 25m, null, "Dragon1abc123", false },
                    { 3, "The Fairy is a tiny magical being. They are about the size of an adult hand, faster than light, and have special fairy dust.", "/Assets/Fairy2Cropped.jpg", "Fairy", null, 30m, null, "Fairy1abc123", false },
                    { 4, "The Griffin is a powerful magical creature. They are about the size of a grown elephant and has 3 times the strength of a whales bite.", "/Assets/Griffin.png", "Griffin", null, 20m, null, "Griffin1abc123", false },
                    { 5, "The Hydra is a tiny but powerful animal, yet as gentle as a dmesticated puppy. They are about the size of two adult hands.", "/Assets/Hydra.png", "Hydra", null, 10m, null, "Hydra1abc123", false },
                    { 6, "The Narwhal is a mystical sea creature who is related to the Unicorn family. They power comes from their horn like the Unicorn, however they are limited to only surviving in water. However, one of their magical powers is changing size to fit whatever water space size.", "/Assets/Narwhal.png", "NawWhal", null, 50m, null, "Narwhal1abc123", false },
                    { 7, "The Troll is a misunderstood being. They often have a facade of ignorance, however they are genius, like Einstein IQ level", "/Assets/Troll.png", "Troll", null, 15m, null, "Troll1abc123", false },
                    { 8, "The Werewolf is a decieving beast because they are human by day, and wolf by night. Becautious as it is unknown but they are the pranksters of the animal world.", "/Assets/WereWolf.png", "Werewolf", null, 15m, null, "Werewolf1abc123", true },
                    { 9, "The Minotaur is a half human half horse. They are the size of a dwarfed giant with a slightly larger horse. Their powers include mind reading and surviving on nothing for a year. They live for several hundreds of years.", "/Assets/Minotaur.jpg", "Minotaur", null, 20m, null, "Minotaur1abc123", false },
                    { 10, "The Mermaid is half human and half fish. Their magic comes from their scales, which allows them to, but not limited to, create an illusion for how others view them.", "/Assets/MermaidCropped.jpg", "Mermaid", null, 40m, null, "Mermaid1abc123", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemsTable_CartID",
                table: "OrderedItemsTable",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemsTable_OrderID",
                table: "OrderedItemsTable",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemsTable_ProductID",
                table: "OrderedItemsTable",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedItemsTable_ShoppingCartItemID",
                table: "OrderedItemsTable",
                column: "ShoppingCartItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderedItemsID",
                table: "Products",
                column: "OrderedItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartItemID",
                table: "Products",
                column: "ShoppingCartItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_CartID",
                table: "ShoppingCartTable",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_OrderedItemsID",
                table: "ShoppingCartTable",
                column: "OrderedItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_ProductID",
                table: "ShoppingCartTable",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItemsTable_Products_ProductID",
                table: "OrderedItemsTable",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedItemsTable_ShoppingCartTable_ShoppingCartItemID",
                table: "OrderedItemsTable",
                column: "ShoppingCartItemID",
                principalTable: "ShoppingCartTable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartTable_Products_ProductID",
                table: "ShoppingCartTable",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemsTable_Carts_CartID",
                table: "OrderedItemsTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartTable_Carts_CartID",
                table: "ShoppingCartTable");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemsTable_OrderTable_OrderID",
                table: "OrderedItemsTable");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemsTable_Products_ProductID",
                table: "OrderedItemsTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartTable_Products_ProductID",
                table: "ShoppingCartTable");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderedItemsTable_ShoppingCartTable_ShoppingCartItemID",
                table: "OrderedItemsTable");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "OrderTable");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCartTable");

            migrationBuilder.DropTable(
                name: "OrderedItemsTable");
        }
    }
}
