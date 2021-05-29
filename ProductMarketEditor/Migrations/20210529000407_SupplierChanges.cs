using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMarketEditor.Migrations
{
    public partial class SupplierChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductChanges_ProductChangeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductChanges",
                table: "ProductChanges");

            migrationBuilder.RenameTable(
                name: "ProductChanges",
                newName: "ProductChange");

            migrationBuilder.AddColumn<int>(
                name: "SupplierChangeId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductChange",
                table: "ProductChange",
                column: "ProductChangeId");

            migrationBuilder.CreateTable(
                name: "SupplierChange",
                columns: table => new
                {
                    SupplierChangeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierChange", x => x.SupplierChangeId);
                });

            migrationBuilder.InsertData(
                table: "SupplierChange",
                columns: new[] { "SupplierChangeId", "CreatedBy", "CreatedOn", "EditedBy", "EditedOn" },
                values: new object[] { 1, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 1,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 3,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 4,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 5,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 6,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 7,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 8,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 9,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 10,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 11,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 12,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 13,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 14,
                column: "SupplierChangeId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_SupplierChangeId",
                table: "Suppliers",
                column: "SupplierChangeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductChange_ProductChangeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_SupplierChange_SupplierChangeId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "SupplierChange");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_SupplierChangeId",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductChange",
                table: "ProductChange");

            migrationBuilder.DropColumn(
                name: "SupplierChangeId",
                table: "Suppliers");

            migrationBuilder.RenameTable(
                name: "ProductChange",
                newName: "ProductChanges");

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
        }
    }
}
