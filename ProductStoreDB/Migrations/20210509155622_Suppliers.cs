using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStoreDB.Migrations
{
    public partial class Suppliers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "LogoFileName", "ProductTypeId", "SupplierName", "SupplierNumber" },
                values: new object[] { 1, "D:\\VUM STUDY\\1 year 2 semester\\DDS\\Assignment\\Logos\\burum.jpg", 11, "Burum", null });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "LogoFileName", "ProductTypeId", "SupplierName", "SupplierNumber" },
                values: new object[] { 2, null, 3, "Prostokvashino", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierID",
                keyValue: 2);
        }
    }
}
