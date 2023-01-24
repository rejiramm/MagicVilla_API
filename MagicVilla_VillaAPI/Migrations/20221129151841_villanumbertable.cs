using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    public partial class villanumbertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaID = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updatedate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaID",
                        column: x => x.VillaID,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createddate",
                value: new DateTime(2022, 11, 29, 20, 48, 41, 58, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createddate",
                value: new DateTime(2022, 11, 29, 20, 48, 41, 58, DateTimeKind.Local).AddTicks(7915));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Createddate",
                value: new DateTime(2022, 11, 29, 20, 48, 41, 58, DateTimeKind.Local).AddTicks(7916));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Createddate",
                value: new DateTime(2022, 11, 29, 20, 48, 41, 58, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "Createddate",
                value: new DateTime(2022, 11, 29, 20, 48, 41, 58, DateTimeKind.Local).AddTicks(7918));

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers",
                column: "VillaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

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
    }
}
