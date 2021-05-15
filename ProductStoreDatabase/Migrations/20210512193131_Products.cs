using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStoreDatabase.Migrations
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "PhotoFileName", "ProductName", "SupplierId" },
                values: new object[] { 1, null, "Prostokvashino Milk 3.2%", 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "PhotoFileName", "ProductName", "SupplierId" },
                values: new object[] { 2, "D:\\VUM STUDY\\1 year 2 semester\\DDS\\Assignment\\ProductPhotos\\ProstokvashinoCottageCheese.jpg", "Prostokvashino Cottage Cheese 5 %", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);
        }
    }
}
