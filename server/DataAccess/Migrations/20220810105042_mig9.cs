using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 10, 13, 50, 42, 198, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 10, 13, 50, 42, 198, DateTimeKind.Local).AddTicks(821));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 8, 10, 13, 50, 42, 198, DateTimeKind.Local).AddTicks(778));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 8, 10, 13, 50, 42, 198, DateTimeKind.Local).AddTicks(790));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 9, 22, 12, 6, 115, DateTimeKind.Local).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 9, 22, 12, 6, 115, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 8, 9, 22, 12, 6, 115, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 8, 9, 22, 12, 6, 115, DateTimeKind.Local).AddTicks(7412));
        }
    }
}
