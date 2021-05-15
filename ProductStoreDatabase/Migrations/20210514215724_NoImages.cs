using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStoreDatabase.Migrations
{
    public partial class NoImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "PhotoFileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1,
                column: "LogoFileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2,
                column: "LogoFileName",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "PhotoFileName",
                value: "D:\\VUM STUDY\\1 year 2 semester\\DDS\\Assignment\\ProductPhotos\\ProstokvashinoCottageCheese.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1,
                column: "LogoFileName",
                value: "D:\\VUM STUDY\\1 year 2 semester\\DDS\\Assignment\\Logos\\burum.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2,
                column: "LogoFileName",
                value: "D:\\VUM STUDY\\1 year 2 semester\\DDS\\Assignment\\Logos\\prostokvashino.jpg");
        }
    }
}
