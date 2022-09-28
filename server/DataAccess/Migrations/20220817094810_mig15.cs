using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "InsertTime", "Price" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3766), 800 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "InsertTime", "Price" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3777), 600 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "InsertTime", "Price" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3779), 400 });

            migrationBuilder.InsertData(
                table: "UsingStatuses",
                columns: new[] { "UsingStatusId", "Name" },
                values: new object[] { 2, "SecondHand" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "ColorId", "Description", "InsertTime", "IsOfferable", "IsSold", "Price", "ProductName", "UserId", "UsingStatusId" },
                values: new object[] { 4, 2, 3, 2, "65 INC 3840x2160 Ultra HD 4K ", new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3780), false, true, 1000, "Samsung TV", null, 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "Date", "ImagePath", "ProductId" },
                values: new object[] { 4, new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3807), "5c272f7c-2e29-4f28-9f97-e34c585d3a5d.jpg", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UsingStatuses",
                keyColumn: "UsingStatusId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 17, 12, 7, 56, 16, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 17, 12, 7, 56, 16, DateTimeKind.Local).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 8, 17, 12, 7, 56, 16, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "InsertTime", "Price" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 7, 56, 16, DateTimeKind.Local).AddTicks(5321), 6000 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "InsertTime", "Price" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 7, 56, 16, DateTimeKind.Local).AddTicks(5332), 8000 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "InsertTime", "Price" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 7, 56, 16, DateTimeKind.Local).AddTicks(5334), 6000 });
        }
    }
}
