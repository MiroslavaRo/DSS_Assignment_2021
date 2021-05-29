using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMarketEditor.Migrations
{
    public partial class Logos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1,
                column: "ImageFile",
                value: "burum.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2,
                column: "ImageFile",
                value: "prostokvashino.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 3,
                column: "ImageFile",
                value: "h&s bakery.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 4,
                column: "ImageFile",
                value: "ARYZTA.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 5,
                column: "ImageFile",
                value: "bacardi.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 6,
                column: "ImageFile",
                value: "Corona.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 7,
                column: "ImageFile",
                value: "nescafe.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 8,
                column: "ImageFile",
                value: "nesquik.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 9,
                column: "ImageFile",
                value: "maruhanichiro.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 10,
                column: "ImageFile",
                value: "DairyPure.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 11,
                column: "ImageFile",
                value: "MOWI.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 12,
                column: "ImageFile",
                value: "prima.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 13,
                column: "ImageFile",
                value: "prima.jpg");

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 14,
                column: "ImageFile",
                value: "tysonproduct.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Suppliers");
        }
    }
}
