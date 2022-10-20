using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HettisentialMvc.Migrations
{
    public partial class Hettisential1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Administrators",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2022, 9, 29, 21, 12, 38, 663, DateTimeKind.Utc).AddTicks(6462));

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2022, 9, 29, 21, 12, 38, 663, DateTimeKind.Utc).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2022, 9, 29, 21, 12, 38, 664, DateTimeKind.Utc).AddTicks(6537));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2022, 9, 29, 21, 12, 38, 664, DateTimeKind.Utc).AddTicks(9148));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Administrators");

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2022, 9, 29, 21, 10, 56, 398, DateTimeKind.Utc).AddTicks(6312));

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2022, 9, 29, 21, 10, 56, 398, DateTimeKind.Utc).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2022, 9, 29, 21, 10, 56, 399, DateTimeKind.Utc).AddTicks(2438));

            migrationBuilder.UpdateData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2022, 9, 29, 21, 10, 56, 399, DateTimeKind.Utc).AddTicks(4631));
        }
    }
}
