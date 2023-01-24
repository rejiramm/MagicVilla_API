using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    public partial class Addtable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createddate",
                value: new DateTime(2022, 11, 28, 17, 57, 17, 291, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createddate",
                value: new DateTime(2022, 11, 28, 17, 57, 17, 291, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Createddate",
                value: new DateTime(2022, 11, 28, 17, 57, 17, 291, DateTimeKind.Local).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Createddate",
                value: new DateTime(2022, 11, 28, 17, 57, 17, 291, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Createddate",
                value: new DateTime(2022, 11, 28, 17, 57, 17, 291, DateTimeKind.Local).AddTicks(9804));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
