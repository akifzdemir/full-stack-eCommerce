using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 5, 19, 42, 18, 792, DateTimeKind.Local).AddTicks(7991));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 8, 5, 19, 42, 18, 792, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "ColorId", "Description", "InsertTime", "IsOfferable", "IsSold", "Price", "ProductName", "UserId", "UsingStatusId" },
                values: new object[] { 2, 3, 2, 2, "Asus Vivobook X571GT-HN1012 Intel Core i5 9300H 8GB 512GB SSD GTX1650 Freedos", new DateTime(2022, 8, 5, 19, 42, 18, 792, DateTimeKind.Local).AddTicks(7961), true, false, 8000, "Asus Laptop", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "Date", "ImagePath", "ProductId" },
                values: new object[] { 2, new DateTime(2022, 8, 5, 19, 42, 18, 792, DateTimeKind.Local).AddTicks(7992), "9c21406c-7319-42e2-9e07-1aacbbf798fa.jpg", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 5, 10, 53, 49, 795, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "InsertTime",
                value: new DateTime(2022, 8, 5, 10, 53, 49, 795, DateTimeKind.Local).AddTicks(954));
        }
    }
}
