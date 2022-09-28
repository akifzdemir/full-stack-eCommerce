using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "ColorId", "Description", "InsertTime", "IsOfferable", "IsSold", "Price", "ProductName", "UserId", "UsingStatusId" },
                values: new object[] { 3, 2, 1, 1, "Samsung Galaxy A32 128 GB", new DateTime(2022, 8, 11, 13, 26, 8, 417, DateTimeKind.Local).AddTicks(5101), true, false, 6000, "Samsung Telefon", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "Date", "ImagePath", "ProductId" },
                values: new object[] { 3, new DateTime(2022, 8, 11, 13, 26, 8, 417, DateTimeKind.Local).AddTicks(5170), "94e5554d-ffa6-4d7d-8c3a-297a8681fc8d.jpg", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 11, 13, 7, 57, 942, DateTimeKind.Local).AddTicks(2643));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 11, 13, 7, 57, 942, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 8, 11, 13, 7, 57, 942, DateTimeKind.Local).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 8, 11, 13, 7, 57, 942, DateTimeKind.Local).AddTicks(2610));
        }
    }
}
