using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddSecondUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "09549acc-0229-43fb-a385-fda1cc2c2187");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03154b8f-b468-4c50-91ff-107c6b1b7cdc", "AQAAAAEAACcQAAAAEE919t96KXbL477/J+Ntx0S44qrdq5xHvjAYPxEPdmYBlP7q6i1x36jd2zZJLfLlMw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2L, 0, "e31ae066-76c9-424a-9b52-2e3bb87a511b", null, false, false, null, null, "ADMIN1", "AQAAAAEAACcQAAAAEPkZ9LQwYJVmb0ZVc4CoOLDdsCzHZIJpD7JlxD9gGh4cF2APYA/aU63ZYK4Qt/3T8w==", null, false, null, false, "admin1" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2019, 4, 30, 10, 47, 33, 878, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "1285759605");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L);

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
    }
}
