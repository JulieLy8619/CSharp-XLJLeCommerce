using Microsoft.EntityFrameworkCore.Migrations;

namespace XLJLeCommerce.Migrations.CreaturesDbcontextMigrations
{
    public partial class _022719rebulddb8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
