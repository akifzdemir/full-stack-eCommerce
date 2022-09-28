using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 3, "TV" });

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
                columns: new[] { "Description", "InsertTime", "IsOfferable", "ProductName" },
                values: new object[] { "Apple Iphone 7 128GB", new DateTime(2022, 8, 17, 12, 7, 56, 16, DateTimeKind.Local).AddTicks(5321), false, "Iphone 7" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 8, 17, 12, 7, 56, 16, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "InsertTime", "IsOfferable", "IsSold", "ProductName" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 7, 56, 16, DateTimeKind.Local).AddTicks(5334), false, true, "Samsung Telephone" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 14, 23, 28, 5, 887, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 14, 23, 28, 5, 887, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 8, 14, 23, 28, 5, 887, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "Description", "InsertTime", "IsOfferable", "ProductName" },
                values: new object[] { "Apple Telefon", new DateTime(2022, 8, 14, 23, 28, 5, 887, DateTimeKind.Local).AddTicks(7987), true, "Telefon" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "InsertTime",
                value: new DateTime(2022, 8, 14, 23, 28, 5, 887, DateTimeKind.Local).AddTicks(7999));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "InsertTime", "IsOfferable", "IsSold", "ProductName" },
                values: new object[] { new DateTime(2022, 8, 14, 23, 28, 5, 887, DateTimeKind.Local).AddTicks(8000), true, false, "Samsung Telefon" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[] { 1, 1, 1 });
        }
    }
}
