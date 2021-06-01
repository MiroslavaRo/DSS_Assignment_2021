using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMarketEditor.Migrations
{
    public partial class ChangeDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductChange_ProductChangeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_SupplierChange_SupplierChangeId",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierChange",
                table: "SupplierChange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductChange",
                table: "ProductChange");

            migrationBuilder.RenameTable(
                name: "SupplierChange",
                newName: "SupplierChanges");

            migrationBuilder.RenameTable(
                name: "ProductChange",
                newName: "ProductChanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierChanges",
                table: "SupplierChanges",
                column: "SupplierChangeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductChanges",
                table: "ProductChanges",
                column: "ProductChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductChanges_ProductChangeId",
                table: "Products",
                column: "ProductChangeId",
                principalTable: "ProductChanges",
                principalColumn: "ProductChangeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_SupplierChanges_SupplierChangeId",
                table: "Suppliers",
                column: "SupplierChangeId",
                principalTable: "SupplierChanges",
                principalColumn: "SupplierChangeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductChanges_ProductChangeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_SupplierChanges_SupplierChangeId",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierChanges",
                table: "SupplierChanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductChanges",
                table: "ProductChanges");

            migrationBuilder.RenameTable(
                name: "SupplierChanges",
                newName: "SupplierChange");

            migrationBuilder.RenameTable(
                name: "ProductChanges",
                newName: "ProductChange");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierChange",
                table: "SupplierChange",
                column: "SupplierChangeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductChange",
                table: "ProductChange",
                column: "ProductChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductChange_ProductChangeId",
                table: "Products",
                column: "ProductChangeId",
                principalTable: "ProductChange",
                principalColumn: "ProductChangeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_SupplierChange_SupplierChangeId",
                table: "Suppliers",
                column: "SupplierChangeId",
                principalTable: "SupplierChange",
                principalColumn: "SupplierChangeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
