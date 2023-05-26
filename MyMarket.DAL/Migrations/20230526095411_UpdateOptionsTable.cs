using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMarket.DAL.Migrations
{
    public partial class UpdateOptionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b87de5b-932d-48f7-b368-750213c07cec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f78da80-7f65-462d-9f4c-cadc06ab8885");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Options",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "26203f9a-d9e9-4fea-a108-8416c6c05feb", "d080ab43-6695-417e-86ee-6614c2958f77", "Role", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "cd925b8c-e7ed-4714-a8d2-acd111f0da37", "3452cdd4-204a-4207-9bc6-0f8f98f9dc56", "Role", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26203f9a-d9e9-4fea-a108-8416c6c05feb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd925b8c-e7ed-4714-a8d2-acd111f0da37");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Options",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "2b87de5b-932d-48f7-b368-750213c07cec", "78fc0d06-b77c-4c1d-a549-962f44defa4e", "Role", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "3f78da80-7f65-462d-9f4c-cadc06ab8885", "86374e14-1206-4660-bf96-45be16626f2d", "Role", "Admin", "ADMIN" });
        }
    }
}
