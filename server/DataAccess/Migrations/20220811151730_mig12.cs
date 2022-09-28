using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 11, 18, 17, 30, 239, DateTimeKind.Local).AddTicks(3386));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 11, 18, 17, 30, 239, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 8, 11, 18, 17, 30, 239, DateTimeKind.Local).AddTicks(3388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 8, 11, 18, 17, 30, 239, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 8, 11, 18, 17, 30, 239, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 8, 11, 18, 17, 30, 239, DateTimeKind.Local).AddTicks(3297));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 11, 13, 26, 8, 417, DateTimeKind.Local).AddTicks(5158));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 11, 13, 26, 8, 417, DateTimeKind.Local).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 8, 11, 13, 26, 8, 417, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 8, 11, 13, 26, 8, 417, DateTimeKind.Local).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 8, 11, 13, 26, 8, 417, DateTimeKind.Local).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "InsertTime",
                value: new DateTime(2022, 8, 11, 13, 26, 8, 417, DateTimeKind.Local).AddTicks(5101));
        }
    }
}
