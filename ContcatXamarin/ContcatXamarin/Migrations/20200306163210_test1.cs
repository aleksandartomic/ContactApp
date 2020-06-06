using Microsoft.EntityFrameworkCore.Migrations;

namespace ContcatXamarin.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1.0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "LastName", "Name", "Number" },
                values: new object[] { 1, "CCC", "BBB", "AAA", 18 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<double>(
                name: "Id",
                table: "Users",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "LastName", "Name", "Number" },
                values: new object[] { 1.0, "CCC", "BBB", "AAA", 18 });
        }
    }
}
