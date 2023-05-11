using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMarket.DAL.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "71b7669d-9140-4c8c-be57-a030c0a0c305", "b13f1085-a39a-4980-bcaf-0291659235f0", "Role", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "b353b2d5-adbe-48d4-a349-8c9f3200d55b", "e39bc376-960b-44fd-b9f1-38ef72afb3b2", "Role", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71b7669d-9140-4c8c-be57-a030c0a0c305");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b353b2d5-adbe-48d4-a349-8c9f3200d55b");
        }
    }
}
