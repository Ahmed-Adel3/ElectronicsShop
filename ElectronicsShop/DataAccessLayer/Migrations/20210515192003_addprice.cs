using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OriginalPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ty74cf0–7h67–bnu5-fh67-45t706d72huy",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6691dd71-2bf8-486d-ae4f-1874743bd538", "AQAAAAEAACcQAAAAEISQYrF0qRasj9TOm9FiTya0uhRuPXljlnrYxQdckOgKZLsdIqmXrZ+1MCUlTiSBIg==", "7f373a7b-c210-4fcb-92e8-0a01612a4b74" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66374cf0–7hur–bnu5-rf57-3r5706d72bgt",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dee7b2b-ab3b-4db5-841b-892845054955", "AQAAAAEAACcQAAAAEJ220miLJ3vPVM4dTJttTpoNOTaeB6a5NeeTU94CU45gy8NxeATDtO67F/rlX/gO0A==", "24e5a80f-0d19-47d2-90e4-f6b1959ecafd" });
        }
    }
}
