using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMarket.DAL.Migrations
{
    public partial class AddStaticOptionParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14d60365-180c-40b3-a638-e9691c30ba26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "952fca30-09b6-4ea2-88e1-ec7d64071cbd");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "StaticOptions",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "69d608fd-aae3-4963-bcbd-c27f3ca05a5d", "d5c6e1a6-b658-4012-a1f3-b9ee70ba970e", "Role", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "7373d5ed-c7ed-4e22-a08e-1f56154d8c2d", "ef47230c-822a-4f0f-b656-acb2ade46c65", "Role", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_StaticOptions_ParentId",
                table: "StaticOptions",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaticOptions_StaticOptions_ParentId",
                table: "StaticOptions",
                column: "ParentId",
                principalTable: "StaticOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaticOptions_StaticOptions_ParentId",
                table: "StaticOptions");

            migrationBuilder.DropIndex(
                name: "IX_StaticOptions_ParentId",
                table: "StaticOptions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69d608fd-aae3-4963-bcbd-c27f3ca05a5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7373d5ed-c7ed-4e22-a08e-1f56154d8c2d");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "StaticOptions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "14d60365-180c-40b3-a638-e9691c30ba26", "e4db1dc1-9b6b-4c3b-96b9-9e1a98bdec3e", "Role", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "952fca30-09b6-4ea2-88e1-ec7d64071cbd", "9554dec1-8f9e-418c-a774-c22e8ecb091d", "Role", "Admin", "ADMIN" });
        }
    }
}
