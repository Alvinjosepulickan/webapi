using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magic_villa.Migrations
{
    public partial class foreignkeyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 58, 30, 942, DateTimeKind.Local).AddTicks(6684));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 58, 30, 942, DateTimeKind.Local).AddTicks(6701));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 58, 30, 942, DateTimeKind.Local).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 58, 30, 942, DateTimeKind.Local).AddTicks(6704));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 58, 30, 942, DateTimeKind.Local).AddTicks(6705));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 53, 45, 674, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 53, 45, 674, DateTimeKind.Local).AddTicks(4547));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 53, 45, 674, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 53, 45, 674, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 24, 1, 53, 45, 674, DateTimeKind.Local).AddTicks(4550));
        }
    }
}
