using Microsoft.EntityFrameworkCore.Migrations;

namespace XLJLeCommerce.Migrations.CreaturesDbcontextMigrations
{
    public partial class redo022219g : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "~Unicorn.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageURL",
                value: "~Dragon2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageURL",
                value: "~Fairy2Cropped.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageURL",
                value: "~Griffin.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageURL",
                value: "~Hydra.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageURL",
                value: "~Narwhal.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageURL",
                value: "~Troll.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageURL",
                value: "~WereWolf.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImageURL",
                value: "~Minotaur.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageURL",
                value: "~MermaidCropped.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "~/Unicorn.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageURL",
                value: "~/Dragon2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageURL",
                value: "~/Fairy2Cropped.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageURL",
                value: "~/Griffin.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageURL",
                value: "~/Hydra.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageURL",
                value: "~/Narwhal.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageURL",
                value: "~/Troll.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageURL",
                value: "~/WereWolf.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImageURL",
                value: "~/Minotaur.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageURL",
                value: "~/MermaidCropped.jpg");
        }
    }
}
