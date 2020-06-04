using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddPasswordSeedingToRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "b1d7f446-f462-4bcb-8970-71f92061a862");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "69e27eef-3f7e-456a-9056-b94057d0846f", "AQAAAAEAACcQAAAAEHDfANTYAkN5F5sqwkRGfKL5jfRV5wq257WLk4U+04VGx2QafoGgdrEwA6ElSjjA8Q==" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2019, 4, 30, 10, 40, 29, 174, DateTimeKind.Utc).AddTicks(2038));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "258113043");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "3039c653-1237-4556-b123-7b0b9405e67f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6f7df06-a7ad-48e5-be64-48d5475bcdba", "AQAAAAEAACcQAAAAEBybF3fHjjOuv0/jgRE9wNzOWUpgHZy1secJsbllg4jpl1h6x97PsNNGSh3GxJ7Kdw==" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2019, 4, 27, 14, 18, 22, 878, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: null);
        }
    }
}
