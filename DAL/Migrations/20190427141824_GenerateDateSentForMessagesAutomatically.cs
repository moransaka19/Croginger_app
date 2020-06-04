using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class GenerateDateSentForMessagesAutomatically : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSent",
                table: "Messages",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSent",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "32105a2a-7930-43eb-a967-213b380a8bad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2bda478-35c8-4066-a055-6d24a2a3f5f3", "AQAAAAEAACcQAAAAEDHUSRYu1pkwRHdsqJDs3TKHs9yEqky04+ue+DuwavIRIuOY3M71Bzm3IOEpeKTArA==" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2019, 4, 27, 8, 50, 6, 743, DateTimeKind.Utc).AddTicks(7481));
        }
    }
}
