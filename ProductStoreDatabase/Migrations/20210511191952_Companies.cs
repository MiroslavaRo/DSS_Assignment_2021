using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStoreDatabase.Migrations
{
    public partial class Companies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Company", "LogoFileName", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, "Burum", "D:\\VUM STUDY\\1 year 2 semester\\DDS\\Assignment\\Logos\\burum.jpg", 11 },
                    { 2, "Prostokvashino", "D:\\VUM STUDY\\1 year 2 semester\\DDS\\Assignment\\Logos\\prostokvashino.jpg", 3 },
                    { 3, "H&S Bakery", null, 4 },
                    { 4, "Aryzita", null, 4 },
                    { 5, "Bacardi", null, 6 },
                    { 6, "Corona", null, 6 },
                    { 7, "Nescafe", null, 5 },
                    { 8, "Nesquik", null, 5 },
                    { 9, "Maruha Nichiro", null, 11 },
                    { 10, "Dairy Pure", null, 3 },
                    { 11, "Mowi", null, 11 },
                    { 12, "Prima", null, 1 },
                    { 13, "Prima", null, 2 },
                    { 14, "Tyson Product", null, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 14);
        }
    }
}
