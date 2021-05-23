using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductMarketEditor.Migrations
{
    public partial class ChangeTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "ProductChangeId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { "2021/05/20 11:30:30 AM", "2021/05/20 11:30:30 AM" });

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "ProductChangeId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { "2021/05/20 11:30:30 AM", "2021/05/20 11:30:30 AM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "ProductChangeId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { "20/05/2021 23:30", "20/05/2021 23:30" });

            migrationBuilder.UpdateData(
                table: "ProductChanges",
                keyColumn: "ProductChangeId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "EditedOn" },
                values: new object[] { "20/05/2021 23:30", "20/05/2021 23:30" });
        }
    }
}
