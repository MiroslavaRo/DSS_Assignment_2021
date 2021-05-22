using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMarketEditor.Migrations
{
    public partial class NewPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductChanges",
                columns: new[] { "ProductChangeId", "CreatedBy", "CreatedOn", "EditedBy", "EditedOn", "ProductId" },
                values: new object[,]
                {
                    { 1, "LindaCole", "20/05/2021 23:30", "LindaCole", "20/05/2021 23:30", 1 },
                    { 2, "LindaCole", "20/05/2021 23:30", "LindaCole", "20/05/2021 23:30", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductPhotos",
                columns: new[] { "ProductPhotoId", "FileName", "ProductId" },
                values: new object[,]
                {
                    { 1, "1.jpg", 1 },
                    { 2, "2.jpg", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ImageFileName",
                value: "1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ImageFileName",
                value: "2.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductChanges",
                keyColumn: "ProductChangeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductChanges",
                keyColumn: "ProductChangeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductPhotos",
                keyColumn: "ProductPhotoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductPhotos",
                keyColumn: "ProductPhotoId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ImageFileName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ImageFileName",
                value: null);
        }
    }
}
