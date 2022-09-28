using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 20, 10, 11, 38, 894, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 20, 10, 11, 38, 894, DateTimeKind.Local).AddTicks(1399));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 8, 20, 10, 11, 38, 894, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 8, 20, 10, 11, 38, 894, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AccessFailedCount", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { 1, 0, "akif@ozdemir.com", "Mehmet Akif", "Özdemir", new byte[] { 227, 221, 215, 104, 155, 49, 89, 83, 153, 219, 18, 219, 105, 23, 255, 15, 199, 52, 218, 20, 39, 1, 105, 79, 146, 44, 195, 202, 79, 180, 145, 68, 52, 229, 254, 136, 236, 143, 140, 18, 247, 108, 7, 198, 4, 136, 213, 77, 239, 27, 98, 233, 209, 27, 50, 147, 147, 27, 171, 31, 67, 146, 45, 132 }, new byte[] { 38, 34, 84, 70, 210, 172, 128, 93, 173, 220, 66, 71, 48, 29, 108, 209, 119, 139, 103, 244, 232, 39, 132, 87, 239, 34, 191, 172, 20, 24, 21, 125, 111, 30, 123, 172, 89, 254, 163, 37, 239, 91, 180, 229, 6, 179, 230, 61, 13, 90, 177, 95, 182, 23, 57, 123, 129, 160, 54, 231, 69, 62, 181, 92, 182, 113, 166, 89, 167, 8, 41, 63, 250, 185, 0, 163, 227, 188, 129, 65, 160, 138, 111, 100, 241, 201, 98, 6, 107, 187, 147, 46, 241, 253, 70, 45, 86, 172, 139, 107, 130, 66, 80, 215, 211, 213, 116, 124, 201, 238, 169, 196, 94, 155, 47, 217, 202, 255, 161, 247, 86, 120, 222, 20, 124, 151, 62, 82 }, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "InsertTime", "UserId" },
                values: new object[] { new DateTime(2022, 8, 20, 10, 11, 38, 894, DateTimeKind.Local).AddTicks(1350), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "InsertTime", "UserId" },
                values: new object[] { new DateTime(2022, 8, 20, 10, 11, 38, 894, DateTimeKind.Local).AddTicks(1361), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "InsertTime", "UserId" },
                values: new object[] { new DateTime(2022, 8, 20, 10, 11, 38, 894, DateTimeKind.Local).AddTicks(1362), 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "InsertTime", "UserId" },
                values: new object[] { new DateTime(2022, 8, 20, 10, 11, 38, 894, DateTimeKind.Local).AddTicks(1363), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

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
                table: "ProductImages",
                keyColumn: "ProductImageId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3807));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "InsertTime", "UserId" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3766), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "InsertTime", "UserId" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3777), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "InsertTime", "UserId" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3779), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "InsertTime", "UserId" },
                values: new object[] { new DateTime(2022, 8, 17, 12, 48, 10, 582, DateTimeKind.Local).AddTicks(3780), null });
        }
    }
}
