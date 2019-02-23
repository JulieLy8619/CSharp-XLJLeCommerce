using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XLJLeCommerce.Migrations.CreaturesDbcontextMigrations
{
    public partial class redo02221e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    VIPItem = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "ImageURL", "Name", "Price", "Sku", "VIPItem" },
                values: new object[,]
                {
                    { 1, "The Unicorn is like a horse but has a magical horn that makes it more and better than a standard horse.", "~/Unicorn.png", "Unicorn", 20m, "Unicorn1abc123", true },
                    { 2, "The Dragon is a powerful magical lizard. About 30 times the size of a normal lizard and has special powers like breaths fire.", "~/Dragon2.png", "Dragon", 25m, "Dragon1abc123", false },
                    { 3, "The Fairy is a tiny magical being. They are about the size of an adult hand, faster than light, and have special fairy dust.", "~/Fairy2Cropped.jpg", "Fairy", 30m, "Fairy1abc123", false },
                    { 4, "The Griffin is a powerful magical creature. They are about the size of a grown elephant and has 3 times the strength of a whales bite.", "~/Griffin.png", "Griffin", 20m, "Griffin1abc123", false },
                    { 5, "The Hydra is a tiny but powerful animal, yet as gentle as a dmesticated puppy. They are about the size of two adult hands.", "~/Hydra.png", "Hydra", 10m, "Hydra1abc123", false },
                    { 6, "The Narwhal is a mystical sea creature who is related to the Unicorn family. They power comes from their horn like the Unicorn, however they are limited to only surviving in water. However, one of their magical powers is changing size to fit whatever water space size.", "~/Narwhal.png", "NawWhal", 50m, "Narwhal1abc123", false },
                    { 7, "The Troll is a misunderstood being. They often have a facade of ignorance, however they are genius, like Einstein IQ level", "~/Troll.png", "Troll", 15m, "Troll1abc123", false },
                    { 8, "The Werewolf is a decieving beast because they are human by day, and wolf by night. Becautious as it is unknown but they are the pranksters of the animal world.", "~/WereWolf.png", "Werewolf", 15m, "Werewolf1abc123", true },
                    { 9, "The Minotaur is a half human half horse. They are the size of a dwarfed giant with a slightly larger horse. Their powers include mind reading and surviving on nothing for a year. They live for several hundreds of years.", "~/Minotaur.jpg", "Minotaur", 20m, "Minotaur1abc123", false },
                    { 10, "The Mermaid is half human and half fish. Their magic comes from their scales, which allows them to, but not limited to, create an illusion for how others view them.", "~/MermaidCropped.jpg", "Mermaid", 40m, "Mermaid1abc123", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
