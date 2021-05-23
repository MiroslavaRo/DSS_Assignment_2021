using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMarketEditor.Migrations
{
    public partial class ProductChangesSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductChanges_Products_ProductId",
                table: "ProductChanges");

            migrationBuilder.DropIndex(
                name: "IX_ProductChanges_ProductId",
                table: "ProductChanges");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductChanges");

            migrationBuilder.AddColumn<int>(
                name: "ProductChangeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductChangeId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductChangeId",
                table: "Products",
                column: "ProductChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductChanges_ProductChangeId",
                table: "Products",
                column: "ProductChangeId",
                principalTable: "ProductChanges",
                principalColumn: "ProductChangeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductChanges_ProductChangeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductChangeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductChangeId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductChanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "ProductChangeId",
                keyValue: 1,
                column: "ProductId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "ProductChangeId",
                keyValue: 2,
                column: "ProductId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_ProductChanges_ProductId",
                table: "ProductChanges",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductChanges_Products_ProductId",
                table: "ProductChanges",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
