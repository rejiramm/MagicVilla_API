using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    public partial class addandseedvillatable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createddate",
                value: new DateTime(2022, 11, 26, 19, 47, 45, 444, DateTimeKind.Local).AddTicks(8094));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createddate",
                value: new DateTime(2022, 11, 26, 19, 47, 45, 444, DateTimeKind.Local).AddTicks(8105));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Createddate",
                value: new DateTime(2022, 11, 26, 19, 47, 45, 444, DateTimeKind.Local).AddTicks(8106));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Createddate",
                value: new DateTime(2022, 11, 26, 19, 47, 45, 444, DateTimeKind.Local).AddTicks(8108));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Createddate",
                value: new DateTime(2022, 11, 26, 19, 47, 45, 444, DateTimeKind.Local).AddTicks(8110));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createddate",
                value: new DateTime(2022, 11, 20, 18, 27, 23, 693, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createddate",
                value: new DateTime(2022, 11, 20, 18, 27, 23, 693, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Createddate",
                value: new DateTime(2022, 11, 20, 18, 27, 23, 693, DateTimeKind.Local).AddTicks(6586));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Createddate",
                value: new DateTime(2022, 11, 20, 18, 27, 23, 693, DateTimeKind.Local).AddTicks(6587));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Createddate",
                value: new DateTime(2022, 11, 20, 18, 27, 23, 693, DateTimeKind.Local).AddTicks(6588));
        }
    }
}
