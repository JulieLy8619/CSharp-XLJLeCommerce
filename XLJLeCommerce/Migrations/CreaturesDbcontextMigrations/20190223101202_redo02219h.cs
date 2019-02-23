using Microsoft.EntityFrameworkCore.Migrations;

namespace XLJLeCommerce.Migrations.CreaturesDbcontextMigrations
{
    public partial class redo02219h : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "/Assets/Unicorn.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageURL",
                value: "/Assets/Dragon2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageURL",
                value: "/Assets/Fairy2Cropped.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageURL",
                value: "/Assets/Griffin.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageURL",
                value: "/Assets/Hydra.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageURL",
                value: "/Assets/Narwhal.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageURL",
                value: "/Assets/Troll.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageURL",
                value: "/Assets/WereWolf.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImageURL",
                value: "/Assets/Minotaur.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageURL",
                value: "/Assets/MermaidCropped.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "ImageURL",
                value: "/Assets/Unicorn.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                column: "ImageURL",
                value: "/Assets/Dragon2.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                column: "ImageURL",
                value: "/Assets/Fairy2Cropped.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                column: "ImageURL",
                value: "/Assets/Griffin.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5,
                column: "ImageURL",
                value: "/Assets/Hydra.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6,
                column: "ImageURL",
                value: "/Assets/Narwhal.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7,
                column: "ImageURL",
                value: "/Assets/Troll.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8,
                column: "ImageURL",
                value: "/Assets/WereWolf.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9,
                column: "ImageURL",
                value: "/Assets/Minotaur.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10,
                column: "ImageURL",
                value: "/Assets/MermaidCropped.jpg");
        }
    }
}
