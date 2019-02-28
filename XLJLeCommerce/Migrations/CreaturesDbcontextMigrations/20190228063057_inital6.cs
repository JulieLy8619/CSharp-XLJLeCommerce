using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XLJLeCommerce.Migrations.CreaturesDbcontextMigrations
{
    public partial class inital6 : Migration
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
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    VIPItem = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartTable",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartID = table.Column<int>(nullable: false),
                    ProdID = table.Column<int>(nullable: false),
                    ProdQty = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
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
                        name: "FK_ShoppingCartTable_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CartID", "Description", "ImageURL", "Name", "Price", "Sku", "VIPItem" },
                values: new object[,]
                {
                    { 1, 0, "The Unicorn is like a horse but has a magical horn that makes it more and better than a standard horse.", "/Assets/Unicorn.png", "Unicorn", 20m, "Unicorn1abc123", true },
                    { 2, 0, "The Dragon is a powerful magical lizard. About 30 times the size of a normal lizard and has special powers like breaths fire.", "/Assets/Dragon2.png", "Dragon", 25m, "Dragon1abc123", false },
                    { 3, 0, "The Fairy is a tiny magical being. They are about the size of an adult hand, faster than light, and have special fairy dust.", "/Assets/Fairy2Cropped.jpg", "Fairy", 30m, "Fairy1abc123", false },
                    { 4, 0, "The Griffin is a powerful magical creature. They are about the size of a grown elephant and has 3 times the strength of a whales bite.", "/Assets/Griffin.png", "Griffin", 20m, "Griffin1abc123", false },
                    { 5, 0, "The Hydra is a tiny but powerful animal, yet as gentle as a dmesticated puppy. They are about the size of two adult hands.", "/Assets/Hydra.png", "Hydra", 10m, "Hydra1abc123", false },
                    { 6, 0, "The Narwhal is a mystical sea creature who is related to the Unicorn family. They power comes from their horn like the Unicorn, however they are limited to only surviving in water. However, one of their magical powers is changing size to fit whatever water space size.", "/Assets/Narwhal.png", "NawWhal", 50m, "Narwhal1abc123", false },
                    { 7, 0, "The Troll is a misunderstood being. They often have a facade of ignorance, however they are genius, like Einstein IQ level", "/Assets/Troll.png", "Troll", 15m, "Troll1abc123", false },
                    { 8, 0, "The Werewolf is a decieving beast because they are human by day, and wolf by night. Becautious as it is unknown but they are the pranksters of the animal world.", "/Assets/WereWolf.png", "Werewolf", 15m, "Werewolf1abc123", true },
                    { 9, 0, "The Minotaur is a half human half horse. They are the size of a dwarfed giant with a slightly larger horse. Their powers include mind reading and surviving on nothing for a year. They live for several hundreds of years.", "/Assets/Minotaur.jpg", "Minotaur", 20m, "Minotaur1abc123", false },
                    { 10, 0, "The Mermaid is half human and half fish. Their magic comes from their scales, which allows them to, but not limited to, create an illusion for how others view them.", "/Assets/MermaidCropped.jpg", "Mermaid", 40m, "Mermaid1abc123", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_CartID",
                table: "ShoppingCartTable",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartTable_ProductID",
                table: "ShoppingCartTable",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartTable");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
