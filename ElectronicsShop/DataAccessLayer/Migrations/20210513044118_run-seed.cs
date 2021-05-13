using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class runseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3417fyr-adr4–4f5e-afbf-58mrryi72gyk", "3417fyr-adr4–4f5e-afbf-58mrryi72gyk", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullAddress", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "66374cf0–7hur–bnu5-rf57-3r5706d72bgt", 0, "8dee7b2b-ab3b-4db5-841b-892845054955", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", true, null, "Application Admin", false, null, null, null, "AQAAAAEAACcQAAAAEJ220miLJ3vPVM4dTJttTpoNOTaeB6a5NeeTU94CU45gy8NxeATDtO67F/rlX/gO0A==", null, false, "24e5a80f-0d19-47d2-90e4-f6b1959ecafd", false, "admin@admin.com" },
                    { "4ty74cf0–7h67–bnu5-fh67-45t706d72huy", 0, "6691dd71-2bf8-486d-ae4f-1874743bd538", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.al.adl333@gmail.com", true, null, "Ahmed Adel", false, null, null, null, "AQAAAAEAACcQAAAAEISQYrF0qRasj9TOm9FiTya0uhRuPXljlnrYxQdckOgKZLsdIqmXrZ+1MCUlTiSBIg==", null, false, "7f373a7b-c210-4fcb-92e8-0a01612a4b74", false, "ahmed.al.adl333@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "ProductTypeId", "TypeNameAr", "TypeNameEn" },
                values: new object[,]
                {
                    { 1, "أجهزة تليفزيون", "Televisions" },
                    { 2, "أجهزة لابتوب", "Laptops" },
                    { 3, "أنظمة صوت", "Sound Systems" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3417fyr-adr4–4f5e-afbf-58mrryi72gyk", "66374cf0–7hur–bnu5-rf57-3r5706d72bgt" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3417fyr-adr4–4f5e-afbf-58mrryi72gyk", "66374cf0–7hur–bnu5-rf57-3r5706d72bgt" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ty74cf0–7h67–bnu5-fh67-45t706d72huy");

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3417fyr-adr4–4f5e-afbf-58mrryi72gyk");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66374cf0–7hur–bnu5-rf57-3r5706d72bgt");
        }
    }
}
