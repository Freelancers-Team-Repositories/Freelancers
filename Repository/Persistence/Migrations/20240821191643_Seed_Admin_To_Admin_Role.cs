using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freelancers.Repository.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Admin_To_Admin_Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ce2fd704-7a3c-4a03-846e-c5479a8b921d", "416282aa-69b8-4f2e-a5d4-6644f2884151" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6CCF2454-C7FE-4F58-89FB-F565AE5643E3", "416282aa-69b8-4f2e-a5d4-6644f2884151" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "416282aa-69b8-4f2e-a5d4-6644f2884151",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOE6yy/4Tvrvk5taJSOf9+oDlRAkxuZd3zWxcI4smd5fL2vvmZx9oqufhuiMfYH/XQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6CCF2454-C7FE-4F58-89FB-F565AE5643E3", "416282aa-69b8-4f2e-a5d4-6644f2884151" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ce2fd704-7a3c-4a03-846e-c5479a8b921d", "416282aa-69b8-4f2e-a5d4-6644f2884151" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "416282aa-69b8-4f2e-a5d4-6644f2884151",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBHAazFJ115hv7B6mvXhkRTin8MmOjwQqVucf1+TMAcTLerT5Qk1TN8OCv2AeHAdmQ==");
        }
    }
}
