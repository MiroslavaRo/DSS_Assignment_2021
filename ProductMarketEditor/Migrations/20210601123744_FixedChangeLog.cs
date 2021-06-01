using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMarketEditor.Migrations
{
    public partial class FixedChangeLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SupplierChange",
                columns: new[] { "SupplierChangeId", "CreatedBy", "CreatedOn", "EditedBy", "EditedOn" },
                values: new object[,]
                {
                    { 2, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 3, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 4, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 5, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 6, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 7, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 8, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 9, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 10, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 11, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 12, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 13, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" },
                    { 14, "LindaCole", "2021/05/20 11:30:30 AM", "LindaCole", "2021/05/20 11:30:30 AM" }
                });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 2,
                column: "SupplierChangeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 3,
                column: "SupplierChangeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 4,
                column: "SupplierChangeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 5,
                column: "SupplierChangeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 6,
                column: "SupplierChangeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 7,
                column: "SupplierChangeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 8,
                column: "SupplierChangeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 9,
                column: "SupplierChangeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 10,
                column: "SupplierChangeId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 11,
                column: "SupplierChangeId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 12,
                column: "SupplierChangeId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 13,
                column: "SupplierChangeId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "SupplierId",
                keyValue: 14,
                column: "SupplierChangeId",
                value: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SupplierChange",
                keyColumn: "SupplierChangeId",
                keyValue: 14);

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
        }
    }
}
