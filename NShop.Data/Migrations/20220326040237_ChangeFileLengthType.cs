using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NShop.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "5b0e2d11-cddf-4ae2-99cc-74ea4061bcb3");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0e71aec1-d9e7-4e03-9fff-9db69512b8d3", "AQAAAAEAACcQAAAAEGEC5IeMwekRbGb8TvY+TJxM5iVskEfgJ+lc5Jchcp6eRmCGOpF+/90Rem+d3C/zIw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 26, 11, 2, 36, 369, DateTimeKind.Local).AddTicks(8963));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "be4165b4-e1de-40a4-8132-951b3ef6fc3d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91e7c5de-3042-419c-9b9b-9a521c95cd87", "AQAAAAEAACcQAAAAEGPcMemTe9JV2Npi4fbqjPe3LHIIy83ySdUUv3ESHz449Y2vI0GX2IZ0VcP+WKdVnA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 3, 24, 16, 59, 33, 283, DateTimeKind.Local).AddTicks(2190));
        }
    }
}
