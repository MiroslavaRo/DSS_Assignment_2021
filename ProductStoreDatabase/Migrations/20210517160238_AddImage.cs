using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductStoreDatabase.Migrations
{
    public partial class AddImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "PhotoFileName",
                value: "Prostokvashino Milk 3.2%.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "PhotoFileName",
                value: null);
        }
    }
}
