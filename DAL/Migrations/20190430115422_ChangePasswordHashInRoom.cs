using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangePasswordHashInRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "dbf47722-6141-4fa9-880d-07593dff1228");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47ecccdc-dc56-4b65-b568-bad2af84519c", "AQAAAAEAACcQAAAAEIMRzEcPUAtK7lOI/LxRU68lGVFKXkWXT2VaU4d2+rg5LF+LHgKlPNd2/hEKh6X1OA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be70c74a-70e7-41ba-8bf3-cd7409c4f6a1", "AQAAAAEAACcQAAAAED5dDU2HLojuvOGgvQi218xirzYlFl3MaEX3mplrfV7T2wWkj2fP2x9YxdShPxFtNw==" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2019, 4, 30, 11, 54, 20, 755, DateTimeKind.Utc).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PasswordHash",
                value: "19513FDC9DA4FB72A4A05EB66917548D3C90FF94D5419E1F2363EEA89DFEE1DD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e31ae066-76c9-424a-9b52-2e3bb87a511b", "AQAAAAEAACcQAAAAEPkZ9LQwYJVmb0ZVc4CoOLDdsCzHZIJpD7JlxD9gGh4cF2APYA/aU63ZYK4Qt/3T8w==" });

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
    }
}
