using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class updateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ty74cf0–7h67–bnu5-fh67-45t706d72huy",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b971d53-4a46-4ba0-ae7d-d38293751bcf", "AQAAAAEAACcQAAAAEBpGP/wwX0GBzIbOYEtSJuUXpDngRvuKyIGvNJRDiXgKt5vZj8HhgfwVHxFv8dv8jQ==", "6977c4cf-e8e9-4735-ae87-bf7f0fa00c1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66374cf0–7hur–bnu5-rf57-3r5706d72bgt",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e16fa42a-91f5-4892-8a32-9c8a45052405", "AQAAAAEAACcQAAAAEDXwegzCRFvUc69S3zD0nnDIziXqYZ8IO8yqwQsnOmhMzHc0YkNBlymndi3nTXZMgQ==", "96f5d517-28c2-41b9-8052-90bdbd54763d" });

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 1,
                column: "TypeNameAr",
                value: "جهاز تلفزيون");

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 2,
                column: "TypeNameAr",
                value: "جهاز لابتوب");

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 3,
                column: "TypeNameAr",
                value: "نظام صوت");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ty74cf0–7h67–bnu5-fh67-45t706d72huy",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5b0c9fd-127b-428d-9e04-699af80c19dc", "AQAAAAEAACcQAAAAEEjdvyiFMbiSs+mRQLf98J+0aXVMC7DTUdsj2t6g8S/2EJUoTI6HhT2XXLF8G5oS5A==", "7f1f840d-df24-4a95-aa34-f8ce291f7ca0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66374cf0–7hur–bnu5-rf57-3r5706d72bgt",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e52f4e7-fef1-4ab4-85f7-e35d31cfc27b", "AQAAAAEAACcQAAAAEDlcv3XuZJvvewuajz+yqkdtCavifg/6VCIVPgzJqZhzjvWCLuPcmE074tScWqhQUg==", "83545dff-d0b4-40cd-9702-250d6f047e79" });

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 1,
                column: "TypeNameAr",
                value: "أجهزة تليفزيون");

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 2,
                column: "TypeNameAr",
                value: "أجهزة لابتوب");

            migrationBuilder.UpdateData(
                table: "ProductTypes",
                keyColumn: "ProductTypeId",
                keyValue: 3,
                column: "TypeNameAr",
                value: "أنظمة صوت");
        }
    }
}
