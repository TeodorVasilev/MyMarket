using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMarket.DAL.Migrations
{
    public partial class AddStaticOptionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23abf27a-a4ea-4b27-9096-02a9156ec17d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbea44ef-4fc9-4629-b34c-8e0c7817bf65");

            migrationBuilder.CreateTable(
                name: "StaticOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticOptions_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "14d60365-180c-40b3-a638-e9691c30ba26", "e4db1dc1-9b6b-4c3b-96b9-9e1a98bdec3e", "Role", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "952fca30-09b6-4ea2-88e1-ec7d64071cbd", "9554dec1-8f9e-418c-a774-c22e8ecb091d", "Role", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_StaticOptions_PropertyId",
                table: "StaticOptions",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaticOptions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14d60365-180c-40b3-a638-e9691c30ba26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "952fca30-09b6-4ea2-88e1-ec7d64071cbd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "23abf27a-a4ea-4b27-9096-02a9156ec17d", "befb5811-19a7-46be-a20e-4c9fa5cb1459", "Role", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "fbea44ef-4fc9-4629-b34c-8e0c7817bf65", "5a4697d2-9dff-4241-a5c5-d028687c0a1a", "Role", "Admin", "ADMIN" });
        }
    }
}
