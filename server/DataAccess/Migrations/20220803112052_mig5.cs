using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "CategoryId", "ColorId", "Description", "InsertTime", "IsOfferable", "IsSold", "Price", "ProductName", "UserId", "UsingStatusId" },
                values: new object[] { 1, 1, 1, 1, "Apple Telefon", new DateTime(2022, 8, 3, 14, 20, 52, 264, DateTimeKind.Local).AddTicks(364), true, false, 6000, "Telefon", null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);
        }
    }
}
