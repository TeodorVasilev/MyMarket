using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMarket.DAL.Migrations
{
    public partial class UpdateImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69d608fd-aae3-4963-bcbd-c27f3ca05a5d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7373d5ed-c7ed-4e22-a08e-1f56154d8c2d");

            migrationBuilder.DropColumn(
                name: "BinaryData",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "2b87de5b-932d-48f7-b368-750213c07cec", "78fc0d06-b77c-4c1d-a549-962f44defa4e", "Role", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "3f78da80-7f65-462d-9f4c-cadc06ab8885", "86374e14-1206-4660-bf96-45be16626f2d", "Role", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b87de5b-932d-48f7-b368-750213c07cec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f78da80-7f65-462d-9f4c-cadc06ab8885");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Images");

            migrationBuilder.AddColumn<byte[]>(
                name: "BinaryData",
                table: "Images",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "69d608fd-aae3-4963-bcbd-c27f3ca05a5d", "d5c6e1a6-b658-4012-a1f3-b9ee70ba970e", "Role", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "7373d5ed-c7ed-4e22-a08e-1f56154d8c2d", "ef47230c-822a-4f0f-b656-acb2ade46c65", "Role", "Admin", "ADMIN" });
        }
    }
}
