using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Farmazon.DAL.Migrations
{
    public partial class FarmazonDALFarmaContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "productId", "productName", "productOwnerId", "productOwnerLastName", "productOwnerName" },
                values: new object[,]
                {
                    { 1L, "Monitor 27", 1L, "Ecer", "Enes" },
                    { 2L, "Klavye", 0L, "", "" },
                    { 3L, "Mekanik Klavye", 1L, "Ecer", "Enes" },
                    { 4L, "Monitor 23", 2L, "Arslan", "Oguzcan" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "dateOfBirth", "email", "firstName", "lastName", "phoneNumber", "userPassword" },
                values: new object[,]
                {
                    { 1L, new DateTime(1995, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "email@mail.com", "Enes", "Ecer", "11223344556677", "pW1234!" },
                    { 2L, new DateTime(1996, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "email2@mail.com", "Oguzcan", "Arslan", "", "Pass1234!" },
                    { 3L, new DateTime(1995, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ali", "Cennet", "113344667799852", "parola789" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "productId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: 3L);
        }
    }
}
